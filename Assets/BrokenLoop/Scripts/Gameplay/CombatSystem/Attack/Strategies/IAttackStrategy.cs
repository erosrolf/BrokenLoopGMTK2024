namespace BrokenLoop.Gameplay
{
    public interface IAttackStrategy
    {
        public void Attack(BaseEnemy[] targets, int damage);
    }
}