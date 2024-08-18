using System.Collections.Generic;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class EnemyFactory : MonoBehaviour
    {
        private Dictionary<EEnemyType, GameObject> _enemyPrefabs;
        private int _lastID;

        private void Awake()
        {
            LoadTilePrefabsFromResources();
        }

        public BaseEnemy CreateInstance(EEnemyType enemyType, Vector3 position, Quaternion rotation = default)
        {
            var instantiate = Instantiate(_enemyPrefabs[enemyType], position, rotation);
            var baseEnemy = instantiate.GetComponent<BaseEnemy>();
            
            return baseEnemy;
        }

        private void LoadTilePrefabsFromResources()
        {
            _enemyPrefabs = new Dictionary<EEnemyType, GameObject>
            {
                { EEnemyType.MeleeOrk , Resources.Load<GameObject>("Enemies/MeleeOrk")},
            };
        }
    }
}