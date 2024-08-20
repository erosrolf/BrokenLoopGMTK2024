using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class XAttackStrategy : IAttackStrategy
    {
        private Transform _transform;
        private GameObject _expsosionPrefab;
        private Vector3[] _directions =
        {
            new Vector3(-1, -1, 0),
            new Vector3(-1, 1, 0),
            new Vector3(1, -1, 0),
            new Vector3(1, 1, 0),
        };
        
        public XAttackStrategy(Transform transform, GameObject explosion)
        {
            _transform = transform;
            _expsosionPrefab = explosion;
        }
        
        public XAttackStrategy(XAttackStrategy other, Transform newTransform)
        {
            _transform = newTransform;
            _expsosionPrefab = other._expsosionPrefab;
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