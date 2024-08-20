using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class BoomXAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private GameObject _explosionPrefab;
        private IAttackStrategy _attackStrategy;

        private void Awake()
        {
            _attackStrategy = new XAttackStrategy(transform, _explosionPrefab);
        }

        public void Attack()
        {
            _attackStrategy.Attack();
        }
    }
}