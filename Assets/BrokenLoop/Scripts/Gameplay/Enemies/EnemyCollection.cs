using System.Collections.Generic;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class EnemyCollection
    {
        private static EnemyCollection _instance;
        public static EnemyCollection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EnemyCollection();
                }
                return _instance;
            }
        }

        private readonly List<BaseEnemy> _enemies;

        private EnemyCollection()
        {
            _enemies = new List<BaseEnemy>();
        }

        public void RegisterEnemy(BaseEnemy enemy)
        {
            if (enemy == null || string.IsNullOrWhiteSpace(enemy.ID)) return;
            if (!_enemies.Contains(enemy))
            {
                _enemies.Add(enemy);
            }
        }

        public void UnregisterEnemy(string id)
        {
            var enemy = GetEnemyById(id);
            if (enemy != null)
            {
                _enemies.Remove(enemy);
            }
        }

        public BaseEnemy GetEnemyById(string id)
        {
            return _enemies.Find(e => e.ID == id);
        }

        public List<BaseEnemy> GetEnemiesInCell(Vector2Int position)
        {
            return _enemies.FindAll(e => HasEnemyInCell(e, position));
        }

        private static bool HasEnemyInCell(BaseEnemy enemy, Vector2Int position)
        {
            var xPos = enemy.transform.position.x;
            var yPos = enemy.transform.position.y;
            return (xPos >= position.x && xPos < position.x + 1) && (yPos >= position.y && yPos < position.y + 1);
        }
    }
}