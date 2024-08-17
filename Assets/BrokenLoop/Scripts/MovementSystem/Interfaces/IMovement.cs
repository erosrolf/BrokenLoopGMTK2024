using UnityEngine;

namespace MovementSystem.Interfaces
{
    public interface IMovement
    {
        void Move(Vector3 direction);
        void RestorePosition(Vector3 position);
    }
}
