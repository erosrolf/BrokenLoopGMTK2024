using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public abstract class BaseBuilding : MonoBehaviour
    {
        public string ID { get; protected set; }
        protected static uint _lastID;
    }
}