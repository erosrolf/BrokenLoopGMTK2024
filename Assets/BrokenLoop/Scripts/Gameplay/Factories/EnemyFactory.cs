using System.Collections.Generic;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class EnemyFactory : MonoBehaviour
    {
        private static EnemyFactory _instance;
        private Dictionary<EEnemyType, GameObject> _enemyPrefabs;
        
        public static EnemyFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<EnemyFactory>();
                    
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<EnemyFactory>();
                        singletonObject.name = typeof(EnemyFactory).ToString();
                    }
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                Debug.LogError("You trying to create a second singletone!");
                return;
            }

            _instance = this;
            
            LoadTilePrefabsFromResources();
            
            DontDestroyOnLoad(this.gameObject);
        }

        public BaseEnemy CreateInstance(EEnemyType enemyType, Vector3 position, Quaternion rotation = default)
        {
            var instantiate = Instantiate(_enemyPrefabs[enemyType], position, rotation);
            var baseEnemy = instantiate.GetComponent<BaseEnemy>();
            EnemyCollection.Instance.RegisterEnemy(baseEnemy);
            return baseEnemy;
        }

        private void LoadTilePrefabsFromResources()
        {
            _enemyPrefabs = new Dictionary<EEnemyType, GameObject>
            {
                { EEnemyType.MeleeOrk , Resources.Load<GameObject>("Enemies/MeleeOrkPrefab")},
            };
        }
    }
}