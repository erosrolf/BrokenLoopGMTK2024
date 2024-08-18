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
        private bool _constructed;
        private SpriteRenderer _spriteRenderer;

        private void FixedUpdate()
        {
            if (_constructed == false)
                return;
            
            Move((Vector3)CalculateDirection());
        }
        
        public override void Construct(string id, int health, int damage, Vector2Int[] path)
        {
            _health = new Health(health, gameObject);
            _movementPath = new Queue<Vector2Int>(path);
            _movement = GetComponent<MovementWithRigidbody2d>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _constructed = true;
        }

        public override void Move(Vector3 direction)
        {
            _spriteRenderer.flipX = direction.x > 0;
            _movement.Move(direction);
        }

        public override void Attack(IDamagable[] targets, IAttackStrategy attackStrategy)
        {
            //TODO: ork attack
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