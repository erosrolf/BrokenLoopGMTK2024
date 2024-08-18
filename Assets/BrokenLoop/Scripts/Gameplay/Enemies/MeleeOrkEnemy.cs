using System;
using MovementSystem;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(MovementWithRigidbody2d))]
    public class MeleeOrkEnemy : BaseEnemy, IDamagable, IAttackable, IMovement
    {
        private MovementWithRigidbody2d _movement;
        private Vector2[] _movementPath;

        private void FixedUpdate()
        {
            throw new NotImplementedException();
        }

        public void Construct(int health, Vector2[] movementPath)
        {
            _health = new Health(health, gameObject);
            _movementPath = movementPath;
            _movement = GetComponent<MovementWithRigidbody2d>();
        }

        public override void Move(Vector3 direction)
        {
            _movement.Move(direction);
        }

        public override void Attack(IDamagable[] targets, IAttackStrategy attackStrategy)
        {
            //TODO: ork attack
        }
    }
}