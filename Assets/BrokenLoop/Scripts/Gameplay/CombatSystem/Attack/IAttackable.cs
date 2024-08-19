namespace BrokenLoop.Gameplay
{
    public interface IAttackable
    {
        public void Attack(IDamagable target, IAttackStrategy attackStrategy);
    }
}