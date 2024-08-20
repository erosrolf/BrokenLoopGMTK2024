using System.Collections;
using Assets.BrokenLoop.Scripts.Gameplay.TileSystem;
using BrokenLoop.Gameplay;
using UnityEngine;

namespace BrokenLoop.Scripts.TileObjects
{
    [RequireComponent(typeof(BoomPlusAttack))]
    public class RookTower : BaseBuilding, IAttackable, IDamagable, IMovebleTilemap
    {
        private BoomPlusAttack _boomPlusAttack;
        private IMovebleTilemap _movebleTilemap;

        [SerializeField, Range(0.1f, 1f)] private float _cooldown;
        public bool IsCanAttack { get; private set; }

        private void Awake()
        {
            Health = 10;
            ID = _lastID++.ToString();
            _boomPlusAttack = GetComponent<BoomPlusAttack>();
            IsCanAttack = true;
            _movebleTilemap = new MoveObjectOnTilemap(gameObject);
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

        public bool Push(Vector3Int direction)
        {
            return _movebleTilemap.Push(direction);
        }
    }
}