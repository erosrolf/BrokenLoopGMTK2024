using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class PlusAttackStrategy : IAttackStrategy
    {
        private Transform _transform;
        private GameObject _expsosionPrefab;
        private Vector3[] _directions = { Vector3.left, Vector3.right, Vector3.up, Vector3.down };

        public PlusAttackStrategy(Transform transform, GameObject explosion)
        {
            _transform = transform;
            _expsosionPrefab = explosion;
        }

        public PlusAttackStrategy(PlusAttackStrategy other, Transform newTransform)
        {
            _expsosionPrefab = other._expsosionPrefab;
            _transform = newTransform;
        }
        
        public void Attack()
        {
            SpawnExplosions();
        }
        
        private void SpawnExplosions()
        {
            foreach (var direction in _directions)
            {
                Object.Instantiate(_expsosionPrefab, _transform.position + direction, Quaternion.identity);
            }
        }
    }
}