using MovementSystem.Helpers;
using System;
using UnityEngine;

namespace MovementSystem.Inputs
{
    public class MovementInput : MonoBehaviour
    {
        public Vector3 MoveDirection => MoveInputToDirection(_moveInputVector2);
        public bool IsInputActive => _moveInputVector2 != Vector2.zero;
        
        private GameInputMap _gameInputMap;
        private Vector2 _moveInputVector2;
        private IsometricViewCorrection _isometricViewCorrection;

        private void Awake()
        {
            _gameInputMap = new GameInputMap();
            _gameInputMap.Gameplay.Move.performed += context => _moveInputVector2 = context.ReadValue<Vector2>();
            _gameInputMap.Gameplay.Move.canceled += context => _moveInputVector2 = Vector2.zero;
            var cameraYRotation = Camera.main != null ? Camera.main.transform.eulerAngles.y : 0.0f; 
            _isometricViewCorrection = new IsometricViewCorrection(cameraYRotation);
        }

        private void OnEnable() => _gameInputMap.Enable();
        private void OnDisable() => _gameInputMap.Disable();

        private Vector3 MoveInputToDirection(Vector2 input)
        {
            Vector3 moveDirection = new Vector3(_moveInputVector2.x, 0, _moveInputVector2.y);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
            _isometricViewCorrection.Correction(ref moveDirection);
            return moveDirection;
        }
    }
}