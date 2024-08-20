using System.Collections;
using BrokenLoop.Gameplay;
using MovementSystem.Interfaces;
using UnityEngine;

namespace BrokenLoop.Scripts.TileObjects
{
    [RequireComponent(typeof(BoomPlusAttack))]
    public class RookTower : BaseBuilding, IAttackable, IDamagable, IMovement
    {
        private BoomPlusAttack _boomPlusAttack;

        [SerializeField, Range(0.1f, 1f)] private float _cooldown;
        public bool IsCanAttack { get; private set; }

        private void Awake()
        {
            Health = 10;
            ID = _lastID++.ToString();
            _boomPlusAttack = GetComponent<BoomPlusAttack>();
            IsCanAttack = true;
        }

        private void Start()
        {
            StartCoroutine(AttackRoutine(3f));
        }

        public void Attack()
        {
            if (IsCanAttack)
            {
                _boomPlusAttack.Attack();
                IsCanAttack = false;
                StartCoroutine(ResetAttackCooldown());
            }
        }

        private IEnumerator ResetAttackCooldown()
        {
            yield return new WaitForSeconds(_cooldown);
            IsCanAttack = true;
        }

        private IEnumerator AttackRoutine(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                _boomPlusAttack.Attack();
            }
        }

        public void Move(Vector3 direction)
        {
            throw new System.NotImplementedException();
        }

        public void RestorePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}