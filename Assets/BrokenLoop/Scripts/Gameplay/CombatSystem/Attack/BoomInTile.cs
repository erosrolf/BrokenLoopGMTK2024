using System.Collections;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class BoomInTile : MonoBehaviour, IAttackable
    {
        private Animator _animator;
        private AttackInCellStrategy _attackStrategy;
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
                yield return new WaitForSeconds(0.2f);
            }
        }

        public void Attack()
        {
            _animator.Play("BoomAnimation");
            _attackStrategy = new AttackInCellStrategy(transform.position, 10);
            _attackStrategy.Attack();
        }
    }
}