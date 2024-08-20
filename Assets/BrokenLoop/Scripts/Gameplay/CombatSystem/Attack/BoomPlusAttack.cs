using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class BoomPlusAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private GameObject _explosionPrefab;
        private IAttackStrategy _attackStrategy;

        private void Awake()
        {
            _attackStrategy = new PlusAttackStrategy(transform, _explosionPrefab);
        }

        public void Attack()
        {
            _attackStrategy.Attack();
        }
    }
}