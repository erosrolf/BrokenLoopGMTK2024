using System.Collections.Generic;
using BrokenLoop.Scripts.Gameplay.Buildings;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace BrokenLoop.Gameplay
{
    public class BuildingsFactory : MonoBehaviour
    {
        private static BuildingsFactory _instance;
        private Dictionary<EBuildingType, GameObject> _tilePrefabs;
        private int _lastId;

        public static BuildingsFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<BuildingsFactory>();
                    
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<BuildingsFactory>();
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
        }

        public BaseBuilding CreateInstance(EBuildingType buildingType, Vector3 position, Quaternion rotation = default)
        {
            if (!_tilePrefabs.TryGetValue(buildingType, out var prefab))
            {
                Debug.LogError($"Prefab for {buildingType} not found!");
                return null;
            }

            var instance = Instantiate(prefab, position, rotation);
            var baseBuilding = instance.GetComponent<BaseBuilding>();
            BuildingCollection.Instance.RegisterBuilding(baseBuilding);
            return baseBuilding;
        }

        private void LoadTilePrefabsFromResources()
        {
            _tilePrefabs = new Dictionary<EBuildingType, GameObject>
            {
                { EBuildingType.RookTower , Resources.Load<GameObject>("Towers/RookTowerPrefab")},
                { EBuildingType.RoundTower , Resources.Load<GameObject>("Towers/RoundTowerPrefab")},
                { EBuildingType.Tron, Resources.Load<GameObject>("TronPrefab")}
            };
        }
    }
}