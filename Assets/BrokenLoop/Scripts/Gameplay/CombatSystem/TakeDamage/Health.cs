using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class Health : IDamagable
    {
        public int Amount { get; private set; }
        
        public Health(int amount)
        {
            Amount = amount;
        }
        
        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Debug.LogError("Try take negative damage!");
                return;
            }

            Amount -= damage;
        }
    }
}