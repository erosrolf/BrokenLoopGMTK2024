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
        private IAttackStrategy _attackStrategy;
        private CircleCollider2D _triggerCollider;

        #region MONO
        private void Awake()
        {
            ID = _lastId++.ToString();
            _health = new Health(10);
            _movement = GetComponent<MovementWithRigidbody2d>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _triggerCollider = gameObject.AddComponent<CircleCollider2D>();
            _triggerCollider.isTrigger = true;
            _triggerCollider.radius = 0.5f;
            _attackStrategy = new SimpleAttackStrategy();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(typeof(BaseBuilding), out var building))
            {
                if (building is IDamagable target)
                {
                    Attack(target, _attackStrategy);
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

        public override void Attack(IDamagable target, IAttackStrategy attackStrategy)
        {
            _attackStrategy.Attack(target, 1); 
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