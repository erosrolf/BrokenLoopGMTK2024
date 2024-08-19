using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class TileResourceForMove: MonoBehaviour
    {
        private static TileResourceForMove _instance;
        public Tilemap tilemap;
        public Tile[] obstacle;
        public Camera _camera;
        List<Vector3> filledCellWorldPositions = new List<Vector3>();
        public float offsetBorder = 1;

        public static TileResourceForMove Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<TileResourceForMove>();

                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<TileResourceForMove>();
                    }
                }

                return _instance;
            }
        }

        public List<Vector3> GetListMoveTile() => filledCellWorldPositions;
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                Debug.LogError("You trying to create a second singletone!");
                return;
            }

            _instance = this;
        }
        private void Start()
        {
            _camera.orthographic = true;
            RefreshGround();
        }
        public void RefreshGround()
        {
            List<Vector3> buffer = new List<Vector3>();

            Vector3 upperRight = _camera.ViewportToWorldPoint(new Vector3(1, 1, _camera.nearClipPlane));
            Vector3 lowerLeft = _camera.ViewportToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
            upperRight.x -= offsetBorder;
            upperRight.y -= offsetBorder;
            lowerLeft.x += offsetBorder;
            lowerLeft.y += offsetBorder;
            BoundsInt bounds = tilemap.cellBounds;
            foreach (var position in bounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile(position);
                if (tile != null && !obstacle.Contains(tile))
                {
                    Vector3 worldPosition = tilemap.GetCellCenterWorld(position);
                    if (worldPosition.x < upperRight.x && worldPosition.x > lowerLeft.x &&
                        worldPosition.y > lowerLeft.y && worldPosition.y < upperRight.y)
                    {
                        buffer.Add(worldPosition);
                    }
                }
            }
            filledCellWorldPositions.Clear();
            filledCellWorldPositions.AddRange(buffer);
        }
    }
}
