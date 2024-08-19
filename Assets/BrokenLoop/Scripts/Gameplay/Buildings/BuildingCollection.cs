using System.Collections.Generic;
using BrokenLoop.Gameplay;
using UnityEngine;

namespace BrokenLoop.Scripts.Gameplay.Buildings
{
    public class BuildingCollection
    {
        private static BuildingCollection _instance;
        public static BuildingCollection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BuildingCollection();
                }
                return _instance;
            }
        }

        private readonly List<BaseBuilding> _buildings;

        private BuildingCollection()
        {
            _buildings = new List<BaseBuilding>();
        }

        public void RegisterBuilding(BaseBuilding building)
        {
            if (building == null || string.IsNullOrWhiteSpace(building.ID)) return;
            if (!_buildings.Contains(building))
            {
                _buildings.Add(building);
            }
        }

        public void UnregisterEnemy(string id)
        {
            var building = GetBuildingById(id);
            if (building != null)
            {
                _buildings.Remove(building);
            }
        }

        public BaseBuilding GetBuildingById(string id)
        {
            return _buildings.Find(b => b.ID == id);
        }

        public BaseBuilding GetBuildingInCell(Vector2Int position)
        {
            return _buildings.Find(e => HasEnemyInCell(e, position));
        }

        private static bool HasEnemyInCell(BaseBuilding building, Vector2Int position)
        {
            var xPos = building.transform.position.x;
            var yPos = building.transform.position.y;
            return (xPos >= position.x && xPos < position.x + 1) && (yPos >= position.y && yPos < position.y + 1);
        }
    }
}