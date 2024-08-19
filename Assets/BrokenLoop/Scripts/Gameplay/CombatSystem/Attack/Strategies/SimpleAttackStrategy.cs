namespace BrokenLoop.Gameplay
{
    public class SimpleAttackStrategy : IAttackStrategy
    {
        public void Attack(IDamagable target, int damage)
        {
            target.TakeDamage(damage);
        }
    }
}