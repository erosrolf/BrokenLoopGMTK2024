using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public abstract class BaseEnemy : IMovement, IAttackable, IDamagable
    {
        protected IAttackStrategy _attackStrategy;
        private GameObject _prefab;
        private Health _health;
        
        public Vector2 Position => (Vector2)_prefab.transform.position;

        public BaseEnemy(GameObject prefab, int health, IAttackStrategy attackStrategy)
        {
            _prefab = prefab;
            _health = new Health(health, _prefab);
            _attackStrategy = attackStrategy;
        }

        public abstract void Move(Vector3 direction);

        public virtual void RestorePosition(Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public abstract void Attack(IDamagable[] targets, IAttackStrategy attackStrategy);

        public void TakeDamage(int damage) => _health.TakeDamage(damage);
    }
}