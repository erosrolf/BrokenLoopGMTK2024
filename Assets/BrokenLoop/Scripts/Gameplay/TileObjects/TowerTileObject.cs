using BrokenLoop.Gameplay;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class TowerTileObject : BaseTileObject, IAttackable, IDamagable, IMovement
    {
        private IAttackStrategy _attackStrategy;
        private Health _health;
        
        public TowerTileObject(string id, GameObject prefab, IAttackStrategy attackStrategy) : base(id, prefab)
        {
            _attackStrategy = attackStrategy;
        }

        public void Attack(IDamagable[] targets, IAttackStrategy attackStrategy)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Move(Vector3 direction)
        {
            throw new System.NotImplementedException();
        }

        public void RestorePosition(Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}