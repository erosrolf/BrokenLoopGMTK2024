using System;
using System.Collections;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class BoomInTile : MonoBehaviour, IAttackable
    {
        private Vector2 damageAreaSize = new Vector2(0.6f, 0.6f); 
        private Color gizmoColor = Color.magenta;
        
        private Animator _animator;
        private IAttackStrategy _attackStrategy;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            StartCoroutine(AttackRoutine());
        }

        public IEnumerator AttackRoutine()
        {
            while (true)
            {
                Attack();
                yield return new WaitForSeconds(0.8f);
            }
        }

        public void Attack()
        {
            // Debug.Log("BoomAnimation");
            // _animator.CrossFade("BoomAnimation", 0);
            _animator.Play("BoomAnimation");
            // _attackStrategy = new AttackInCellStrategy(transform.position, 10);
            _attackStrategy = new AttackInBoxStrategy(transform.position, 10);
            _attackStrategy.Attack();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireCube(transform.position, damageAreaSize);
        }
    }
}