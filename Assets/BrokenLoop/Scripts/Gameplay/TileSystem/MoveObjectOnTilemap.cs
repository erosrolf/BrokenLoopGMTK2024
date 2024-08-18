using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class MoveObjectOnTilemap : IMovebleTile
    {
        private Tilemap _objectMap;
        private Tilemap _tilemap;
        private GameObject _gameObject;
        public MoveObjectOnTilemap(Tilemap tilemap, Tilemap objectMap, GameObject gameObject) { 
            _tilemap = tilemap;
            _gameObject = gameObject;
            _objectMap = objectMap;
        }

        public bool Push(Vector3Int direction)
        {
            var newPosition = _gameObject.transform.position + direction;
            Vector3Int positionOnTile = _tilemap.WorldToCell(newPosition);
            var canMove = CheckTile(positionOnTile);
            if (canMove)
            {
                _gameObject.transform.position = newPosition;
                return true;
            }
            return false;
        }
 
        private bool CheckTile(Vector3Int direction)
        {
            var tile = _tilemap.GetTile(direction);
            if (tile != null)
            {
                return true;
            }
            return false;
        }
    }
}
