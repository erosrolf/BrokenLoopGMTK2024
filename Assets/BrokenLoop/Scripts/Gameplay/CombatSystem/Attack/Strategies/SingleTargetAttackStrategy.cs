namespace BrokenLoop.Gameplay
{
    public class SingleTargetAttackStrategy : IAttackStrategy
    {
        private IDamagable _target;
        private int _damage;
        
        public SingleTargetAttackStrategy(IDamagable target, int damage)
        {
            _target = target;
            _damage = damage;
        }
        
        public void Attack()
        {
            _target.TakeDamage(_damage);
        }
    }
}