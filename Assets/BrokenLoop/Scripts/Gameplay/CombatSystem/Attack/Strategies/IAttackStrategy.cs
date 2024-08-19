namespace BrokenLoop.Gameplay
{
    public interface IAttackStrategy
    {
        public void Attack(IDamagable target, int damage);
    }
}