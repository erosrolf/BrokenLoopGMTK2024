using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class MoveObjectOnTilemap : IMovebleTilemap
    {
        private Tilemap _tilemap;
        private GameObject _gameObject;
        public MoveObjectOnTilemap(Tilemap tilemap, GameObject gameObject) { 
            _tilemap = tilemap;
            _gameObject = gameObject;
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
