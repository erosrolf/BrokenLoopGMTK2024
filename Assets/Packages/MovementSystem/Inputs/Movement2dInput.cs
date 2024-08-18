using MovementSystem.Helpers;
using System;
using UnityEngine;

namespace MovementSystem.Inputs
{
    public class Movement2dInput : MonoBehaviour
    {
        public Vector3 MoveDirection => MoveInputToDirection(_moveInputVector2);
        public bool IsInputActive => _moveInputVector2 != Vector2.zero;
        
        private GameInputMap _gameInputMap;
        private Vector2 _moveInputVector2;

        private void Awake()
        {
            _gameInputMap = new GameInputMap();
            _gameInputMap.Gameplay.Move.performed += context => _moveInputVector2 = context.ReadValue<Vector2>();
            _gameInputMap.Gameplay.Move.canceled += context => _moveInputVector2 = Vector2.zero;
        }

        private void OnEnable() => _gameInputMap.Enable();
        private void OnDisable() => _gameInputMap.Disable();

        private Vector2 MoveInputToDirection(Vector2 input)
        {
            return Vector2.ClampMagnitude(input, 1);
        }
    }
}