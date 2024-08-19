using System;
using System.Collections.Generic;
using System.Linq;
using MovementSystem;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(MovementWithRigidbody2d))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class MeleeOrkEnemy : BaseEnemy, IDamagable, IAttackable, IMovement
    {
        private MovementWithRigidbody2d _movement;
        private Queue<Vector2Int> _movementPath;
        private SpriteRenderer _spriteRenderer;
        private CircleCollider2D _triggerCollider;
        private SingleTargetAttackStrategy _attackStrategy;

        #region MONO
        private void Awake()
        {
            ID = _lastId++.ToString();
            Health = 2;
            _movement = GetComponent<MovementWithRigidbody2d>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _triggerCollider = gameObject.AddComponent<CircleCollider2D>();
            _triggerCollider.isTrigger = true;
            _triggerCollider.radius = 0.5f;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(typeof(BaseBuilding), out var building))
            {
                if (building is IDamagable target)
                {
                    _attackStrategy = new SingleTargetAttackStrategy(target, 2);
                    Attack();
                    EnemyCollection.Instance.UnregisterEnemy(ID);
                    Destroy(gameObject);
                }
            }
        }
        #endregion

        private void FixedUpdate()
        {
            if (_movementPath.Count > 0)
            {
                Move((Vector3)CalculateDirection());
            }
        }
        
        public override void ConstructPath(Vector2Int[] path)
        {
            _movementPath = new Queue<Vector2Int>(path);
        }

        public override void Move(Vector3 direction)
        {
            _spriteRenderer.flipX = direction.x > 0;
            _movement.Move(direction);
        }

        public override void Attack()
        {
            _attackStrategy.Attack();
        }

        public override void TakeDamage(int amount)
        {
            if (amount < 0) return;
            Health -= amount;
            Debug.Log($"Ork taked damage, health amount = {Health}");
            if (Health <= 0)
            {
                EnemyCollection.Instance.UnregisterEnemy(ID);
                Destroy(gameObject);
            }
        }

        private Vector2 CalculateDirection()
        {
            if (_movementPath.Count == 0)
            {
                return Vector2.zero;
            }
            
            Vector2Int tilePosition = new Vector2Int(
                Mathf.FloorToInt(transform.position.x),
                Mathf.FloorToInt(transform.position.y)
            );
            if (_movementPath.First() == tilePosition)
            {
                _movementPath.Dequeue();
            }
            
            if (_movementPath.Count == 0)
            {
                return Vector2.zero;
            }

            Vector2 movementVector = _movementPath.First() - tilePosition;
            return movementVector.normalized;
        }
    }
}