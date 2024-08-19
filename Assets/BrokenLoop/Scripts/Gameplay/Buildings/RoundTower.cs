using Assets.BrokenLoop.Scripts.Gameplay.TileSystem;
using BrokenLoop.Gameplay;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class RoundTower : BaseBuilding, IDamagable, IMovement, IMovebleTilemap
    {
        private IAttackStrategy _attackStrategy;
        private Health _health;
        IMovebleTilemap _movebleTilemap;

        private void Awake()
        {
            ID = _lastID++.ToString();
        }
        private void Start()
        {
            _movebleTilemap = new MoveObjectOnTilemap(gameObject);
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
            transform.position = position;
        }

        public bool Push(Vector3Int direction)
        {
            return _movebleTilemap.Push(direction);
        }
    }
}