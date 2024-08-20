using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class BaseEnemy : MonoBehaviour, IMovement, IAttackable, IDamagable
    {
        public string ID { get; protected set; }
        public int Health { get; protected set; }
        
        protected float _speed;
        protected static uint _lastId;

        public virtual void RestorePosition(Vector3 position)
        {
            transform.position = position;
        }
        public abstract void ConstructPath(Vector2Int[] path);
        public abstract void Move(Vector3 direction);
        public abstract void Attack();
        public abstract void TakeDamage(int damage);
    }
}