using MovementSystem.Interfaces;
using Assets.BrokenLoop.Scripts.Gameplay.TileSystem;
using System.Collections;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(BoomXAttack))]
    public class RoundTower : BaseBuilding, IDamagable, IMovement, IMovebleTilemap
    {
        IMovebleTilemap _movebleTilemap;

        [SerializeField, Range(0.1f, 1f)] private float _cooldown;
        private BoomXAttack _boomXAttack;
        
        public bool IsCanAttack { get; private set; }
        
        private void Awake()
        {
            Health = 10;
            ID = _lastID++.ToString();
            _boomXAttack = GetComponent<BoomXAttack>();
            IsCanAttack = true;
            _movebleTilemap = new MoveObjectOnTilemap(gameObject);
        }
        
        private void Start()
        {
            StartCoroutine(AttackRoutine(3f));
        }

        public void Attack()
        {
            StartCoroutine(AttackRoutine(3f));
        }
        
        public void Move(Vector3 direction)
        {
            throw new System.NotImplementedException();
        }

        public void RestorePosition(Vector3 position)
        {
            transform.position = position;
        }

        public bool Push(Vector3Int direction)
        {
            return _movebleTilemap.Push(direction);
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
                _boomXAttack.Attack();
            }
        }
    }
}