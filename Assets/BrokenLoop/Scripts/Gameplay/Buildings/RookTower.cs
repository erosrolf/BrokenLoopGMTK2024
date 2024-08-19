using BrokenLoop.Gameplay;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Scripts.TileObjects
{
    public class RookTower : BaseBuilding, IAttackable, IDamagable, IMovement, IMovebleTilemap
    {
        private IAttackStrategy _attackStrategy;
        private Health _health;
        IMovebleTilemap _movebleTilemap; // как в него записать new MoveObjectOnTilemap(TileMap по которому двигать, Gameobject который двигать)
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
            return _movebleTilemap.Push(direction); // наш метод для вдижения
        }
    }
}