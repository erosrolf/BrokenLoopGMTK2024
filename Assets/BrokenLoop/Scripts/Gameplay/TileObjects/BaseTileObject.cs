using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public abstract class BaseTileObject
    {
        public readonly string Id;
        private GameObject _prefab;

        public BaseTileObject(string id, GameObject prefab)
        {
            Id = id;
            _prefab = prefab;
        }
    }
}