using System;
using MovementSystem.Inputs;
using MovementSystem.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BrokenLoop.Scripts.Gameplay
{
    [RequireComponent(typeof(Movement2dInput))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        public bool IsLookingRight { get; private set; }
        
        private IMovement _movement;
        private Movement2dInput _movementInput;
        private SpriteRenderer _spriteRenderer;

        #region MONO
        private void Awake()
        {
            _movement = GetComponent<IMovement>() ?? throw new Exception("Player doesn't have movement component!");
            _movementInput = GetComponent<Movement2dInput>();
            IsLookingRight = true;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void FixedUpdate()
        {
            _movement.Move(_movementInput.MoveDirection);
            if (_movementInput.IsInputActive)
            {
                _spriteRenderer.flipX = _movementInput.MoveDirection.x < 0;
            }
        }
        
        #endregion
    }
}