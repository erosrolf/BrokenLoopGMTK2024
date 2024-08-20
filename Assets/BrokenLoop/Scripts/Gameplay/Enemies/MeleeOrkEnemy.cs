using System.Collections.Generic;
using System.Linq;
using MovementSystem;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class MeleeOrkEnemy : BaseEnemy, IDamagable, IAttackable, IMovement
    {
        [SerializeField] private float _moveSpeed = 2f;
        
        private MovementWithRigidbody2d _movement;
        private List<Vector2> _movementPath;
        private SpriteRenderer _spriteRenderer;
        private CircleCollider2D _triggerCollider;
        private SingleTargetAttackStrategy _attackStrategy;
        private int _currentTargetIndex = 0;

        #region MONO
        private void Awake()
        {
            ID = _lastId++.ToString();
            Health = 2;
            _movement = GetComponent<MovementWithRigidbody2d>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _triggerCollider = GetComponent<CircleCollider2D>();
            _triggerCollider.isTrigger = true;
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

        private void Update()
        {
            MoveAlongPath();
        }
        
        public override void ConstructPath(Vector2[] path)
        {
            _movementPath = new List<Vector2>(path);
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

        private void MoveAlongPath()
        {
            if (_currentTargetIndex >= _movementPath.Count) return;
            
            Vector2 targetPosition = _movementPath[_currentTargetIndex];
            float step = _moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                _currentTargetIndex++;
            }
        }
    }
}