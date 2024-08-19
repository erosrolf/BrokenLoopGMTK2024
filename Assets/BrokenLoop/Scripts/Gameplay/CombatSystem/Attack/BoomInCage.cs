using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class BoomInCage : MonoBehaviour, IAttackable
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
        }

        public void Attack(IDamagable target, IAttackStrategy attackStrategy)
        {
            _animator.Play("Boom");
            throw new System.NotImplementedException();
        }
    }
}