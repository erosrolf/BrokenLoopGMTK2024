using System;
using BrokenLoop.Gameplay;
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            var collidedObject = other.gameObject;
            Vector2 otherPosition = collidedObject.transform.position;
            
            if (!collidedObject.TryGetComponent(out BaseBuilding building)) return;

            if (building is IMovebleTilemap pusher)
            {
                pusher.Push((Vector3Int)GetPushDirection(otherPosition));
            }
        }

        private Vector2Int GetPushDirection(Vector2 otherPosition)
        {
            Vector2 myPosition = transform.position;
            Vector2 direction = (otherPosition - myPosition).normalized;
            
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) // Если направлено больше по оси X
            {
                if (direction.x > 0) // Если справа
                {
                    return Vector2Int.right;
                }
                else // Если слева
                {
                    return Vector2Int.left;
                }
            }
            else // Если направлено больше по оси Y
            {
                if (direction.y > 0) // Если сверху
                {
                    return Vector2Int.up;
                }
                else // Если снизу
                {
                    return Vector2Int.down;
                }
            }
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