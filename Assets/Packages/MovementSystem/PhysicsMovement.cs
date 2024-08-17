using MovementSystem.Interfaces;
using UnityEngine;
using MovementSystem.Helpers;

namespace MovementSystem
{
    [RequireComponent(typeof(SurfaceSlider))]
    public class PhysicsMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        
        private SurfaceSlider _surfaceSlider;

        private void Awake()
        {
            _surfaceSlider = GetComponent<SurfaceSlider>();
        }

        public void Move(Vector3 direction)
        {
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);
            
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }

        public void RestorePosition(Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}