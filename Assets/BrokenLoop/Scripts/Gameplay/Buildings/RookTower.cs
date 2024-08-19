using System;
using BrokenLoop.Gameplay;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Scripts.TileObjects
{
    public class RookTower : BaseBuilding, IAttackable, IDamagable, IMovement
    {
        private IAttackStrategy _attackStrategy;

        private void Awake()
        {
            Health = 10;
            ID = _lastID++.ToString();
        }

        public void Attack()
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