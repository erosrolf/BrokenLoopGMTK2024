using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class AttackInBoxStrategy : IAttackStrategy
    {
        public Vector2 damageAreaSize = new Vector2(0.6f, 0.6f);
        private Vector3 _position;
        private int _damage;
        
        public AttackInBoxStrategy(Vector3 position, int damage)
        {
            _position = position;
            _damage = damage;
        }
        
        public void Attack()
        {
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(_position, damageAreaSize, 0f);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent<IDamagable>(out IDamagable damagable))
                {
                    damagable.TakeDamage(_damage);
                }
            }
        }
    }
}