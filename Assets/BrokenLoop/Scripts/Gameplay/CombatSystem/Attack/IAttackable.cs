namespace BrokenLoop.Gameplay
{
    public interface IAttackable
    {
        public void Attack(IDamagable[] targets, IAttackStrategy attackStrategy);
    }
}