using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class BaseEnemy : MonoBehaviour, IMovement, IAttackable, IDamagable
    {
        public string ID { get; protected set; }
        protected Health _health;
        protected float _speed;

        public abstract void Construct(string id, int health, int damage, Vector2Int[] path);
        
        public abstract void Move(Vector3 direction);

        public virtual void RestorePosition(Vector3 position)
        {
            transform.position = position;
        }

        public abstract void Attack(IDamagable[] targets, IAttackStrategy attackStrategy);

        public void TakeDamage(int damage) => _health.TakeDamage(damage);
    }
}