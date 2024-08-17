using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace BrokenLoop.Gameplay.Factory
{
    public class TileObjectFactory : MonoBehaviour
    {
        private Dictionary<ETileObjectType, GameObject> _tilePrefabs;
        private int _lastId;

        private void Awake()
        {
            LoadTilePrefabsFromResources();
        }

        public BaseTileObject CreateTileObject(ETileObjectType tileObjectType, Vector3 position, Quaternion rotation = default)
        {
            if (!_tilePrefabs.TryGetValue(tileObjectType, out var prefab))
            {
                Debug.LogError($"Prefab for {tileObjectType} not found!");
                return null;
            }

            var instance = Instantiate(prefab, position, rotation);
            var tileObjectPrefab = instance.GetComponent<TileObjectPrefab>();
            
            return tileObjectPrefab.BaseTileObject = tileObjectType switch
            {
                ETileObjectType.Forest => new ForestTileObject(NewId(), instance),
                ETileObjectType.Tower => new TowerTileObject(NewId(), instance, null),
                _ => throw new ArgumentException($"{tileObjectType.ToString()}")
            };
        }

        private void LoadTilePrefabsFromResources()
        {
            _tilePrefabs = new Dictionary<ETileObjectType, GameObject>
            {
                { ETileObjectType.Forest , Resources.Load<GameObject>("Prefabs/ForestTileObjectPrefab")},
                { ETileObjectType.Tower , Resources.Load<GameObject>("Prefabs/TowerTileObjectPrefab")}
            };
        }

        private string NewId()
        {
            return _lastId++.ToString();
        }
    }
}