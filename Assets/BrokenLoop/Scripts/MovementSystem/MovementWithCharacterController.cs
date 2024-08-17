using MovementSystem.Interfaces;
using UnityEngine;

namespace MovementSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementWithCharacterController : MonoBehaviour, IMovement
    {
        [SerializeField]
        private float _speedMove;
        [SerializeField, Range(0.3f, 1f)] 
        private float _speedRotation;

        private float _gravityForce;
        private CharacterController _characterController;

        #region MONO
        private void Awake()
        {
            if (_speedRotation < 0.3f)
            {
                _speedRotation = 0.5f;
            }
            _characterController = GetComponent<CharacterController>(); 
        }
        #endregion
        
        private void Update()
        {
            GamingGravity();
        }

        public void Move(Vector3 direction)
        {
            Vector3 moveVector = direction;
            if (_characterController.isGrounded)
            {
                RotateInDirection(direction);
            }
            moveVector.y = _gravityForce; 
            _characterController.Move(moveVector * _speedMove * Time.deltaTime);
        }

        public void RestorePosition(Vector3 position)
        {
            _characterController.enabled = false;
            transform.position = position;
            _characterController.enabled = true;
        }

        private void RotateInDirection(Vector3 direction)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, direction, _speedRotation, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        private void GamingGravity()
        {
            if (_characterController.isGrounded == false)
            {
                _gravityForce -= 20f * Time.deltaTime;
            }
            else
            {
                _gravityForce = -1f;
            }
        }
    }
}