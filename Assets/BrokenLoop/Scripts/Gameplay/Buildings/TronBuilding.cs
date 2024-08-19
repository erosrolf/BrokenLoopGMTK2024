using BrokenLoop.Gameplay;
using UnityEngine;

namespace BrokenLoop.Scripts.Gameplay.Buildings
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class TronBuilding : BaseBuilding, IDamagable
    {
        private void Awake()
        {
            Health = 100;
            ID = "TRON";
        }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            Debug.Log($"Tron take damage, health amount = {Health}");
        }
    }
}