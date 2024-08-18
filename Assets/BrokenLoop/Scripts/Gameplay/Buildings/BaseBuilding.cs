using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public abstract class BaseBuilding : MonoBehaviour
    {
        public string ID { get; protected set; }
        
        public void Construct(string id)
        {
            ID = id;
        }
    }
}