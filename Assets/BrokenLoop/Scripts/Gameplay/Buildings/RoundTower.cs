using BrokenLoop.Gameplay;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class RoundTower : BaseBuilding, IAttackable, IDamagable, IMovement
    {
        private IAttackStrategy _attackStrategy;
        private Health _health;

        public void Attack(IDamagable target, IAttackStrategy attackStrategy)
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
            transform.position = position;
        }
    }
}