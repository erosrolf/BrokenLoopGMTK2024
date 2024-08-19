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
        protected static uint _lastId;

        public virtual void RestorePosition(Vector3 position)
        {
            transform.position = position;
        }
        public abstract void ConstructPath(Vector2Int[] path);
        public abstract void Move(Vector3 direction);


        public abstract void Attack(IDamagable target, IAttackStrategy attackStrategy);

        public void TakeDamage(int damage) => _health.TakeDamage(damage);
    }
}