using BrokenLoop.Gameplay;
using UnityEngine;

namespace BrokenLoop.Scripts.Gameplay.Buildings
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TronBuilding : BaseBuilding, IDamagable
    {
        private Health _health;
        private void Awake()
        {
            ID = "TRON";
            _health = new Health(100);
        }
        
        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            Debug.Log($"Tron was attacked, new health amount = {_health.Amount}");
        }
    }
}