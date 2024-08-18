using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class PositionOnTileCamera
    {
        Tilemap _tilemap;
        Camera _camera;
        Random random = new Random();
        int i = 100;
        public PositionOnTileCamera(Tilemap tilemap, Camera camera)
        { 
            _tilemap = tilemap;
            _camera = camera;
            _camera.orthographic = true;
        }

        public void SetObjectOnMapRandom(GameObject gameObject)
        {
            gameObject.transform.position = GetRandomPointOnTailmap();
        }
        public void SetObjectOnMapToPoint(GameObject gameObject, Vector3 point)
        {
            gameObject.transform.position = GetRandomPointOnTailmap();
        }

        public Vector3 GetRandomPointOnTailmap()
        {
            // Определение случайной позиции на экране
            float randomX = random.Next(0+i, _camera.pixelWidth - i);
            float randomY = random.Next(0+i, _camera.pixelHeight - i);

            // Преобразование координат экрана в мировые координаты
            Vector3 worldPoint = _camera.ScreenToWorldPoint(new Vector3(randomX, randomY, _camera.nearClipPlane));
            worldPoint.z = 0;
            Vector3Int positionOnTile = _tilemap.WorldToCell(worldPoint);
            var point = _tilemap.GetCellCenterWorld(positionOnTile);
            return point;
        }
    }
}
