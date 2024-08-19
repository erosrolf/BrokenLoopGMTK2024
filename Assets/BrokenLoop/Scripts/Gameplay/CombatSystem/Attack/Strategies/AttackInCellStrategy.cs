using BrokenLoop.Scripts.Gameplay.Buildings;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class AttackInCellStrategy : IAttackStrategy
    {
        private int _damage;
        private Vector2Int _position;
        
        public AttackInCellStrategy(Vector3 position, int damage)
        {
            _position = new Vector2Int(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y));
            _damage = damage;
        }
        
        public void Attack()
        {
            Debug.Log(EnemyCollection.Instance.Count);
            var enemies = EnemyCollection.Instance.GetEnemiesInCell(_position);
            Debug.Log($"Enemies count in cell {_position.x}, {_position.y} = {enemies.Count}");
            foreach (var enemy in enemies)
            {
                enemy.TakeDamage(_damage);
            }

            var buildingInCell = BuildingCollection.Instance.GetBuildingInCell(_position);
            if (buildingInCell == null) return;
            if (buildingInCell.TryGetComponent<IDamagable>(out var damagableBuilding))
            {
                damagableBuilding.TakeDamage(_damage);
            }
        }
    }
}