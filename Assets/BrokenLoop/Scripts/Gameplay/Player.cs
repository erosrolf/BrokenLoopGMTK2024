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
        private IMovement _movement;
        private Movement2dInput _movementInput;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;

        #region MONO
        private void Awake()
        {
            _movement = GetComponent<IMovement>() ?? throw new Exception("Player doesn't have movement component!");
            _movementInput = GetComponent<Movement2dInput>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat("Speed", _movementInput.MoveDirection.magnitude);
        }

        private void FixedUpdate()
        {
            _movement.Move(_movementInput.MoveDirection);
            if (_movementInput.MoveDirection.x != 0)
            {
                _spriteRenderer.flipX = _movementInput.MoveDirection.x < 0;
            }
        }
        #endregion
    }
}