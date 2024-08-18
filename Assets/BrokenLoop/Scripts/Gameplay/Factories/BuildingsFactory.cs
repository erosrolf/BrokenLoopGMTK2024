using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace BrokenLoop.Gameplay
{
    public class BuildingsFactory : MonoBehaviour
    {
        private Dictionary<EBuildingType, GameObject> _tilePrefabs;
        private int _lastId;

        private void Awake()
        {
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
            baseBuilding.Construct(NewId());
            return baseBuilding;
        }

        private void LoadTilePrefabsFromResources()
        {
            _tilePrefabs = new Dictionary<EBuildingType, GameObject>
            {
                { EBuildingType.RookTower , Resources.Load<GameObject>("Towers/RookTowerPrefab")},
                { EBuildingType.RoundTower , Resources.Load<GameObject>("Towers/RoundTowerPrefab")}
            };
        }

        private string NewId()
        {
            return _lastId++.ToString();
        }
    }
}