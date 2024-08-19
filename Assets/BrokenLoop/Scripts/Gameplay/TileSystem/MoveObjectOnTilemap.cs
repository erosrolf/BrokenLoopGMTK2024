using UnityEngine;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class MoveObjectOnTilemap : IMovebleTilemap
    {
        private GameObject _gameObject;
        public MoveObjectOnTilemap(GameObject gameObject) { 
            _gameObject = gameObject;
        }

        public bool Push(Vector3Int direction)
        {
            var newPosition = _gameObject.transform.position + direction;
            var canMove = TileResourceForMove.Instance.GetListMoveTile().Contains(newPosition);
            if (canMove)
            {
                _gameObject.transform.position = newPosition;
                return true;
            }
            return false;
        }
    }
}
