using System;
using MovementSystem.Interfaces;
using UnityEngine;

namespace MovementSystem
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementWithRigidbody2d : MonoBehaviour, IMovement
    {
        [SerializeField] private float _speed;
        
        private Rigidbody2D _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = (Vector2)direction * _speed;
        }

        public void RestorePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}