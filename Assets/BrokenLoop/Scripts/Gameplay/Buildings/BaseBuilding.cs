using BrokenLoop.Scripts.Gameplay.Buildings;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public abstract class BaseBuilding : MonoBehaviour, IDamagable
    {
        public int Health { get; protected set; }
        public string ID { get; protected set; }
        protected static uint _lastID;
        
        public virtual void TakeDamage(int amount)
        {
            if (amount < 0) return;
            
            Health -= amount;
            if (Health < 0)
            {
                BuildingCollection.Instance.UnregisterBuilding(ID);
                Destroy(gameObject);
            }
        }
    }
}