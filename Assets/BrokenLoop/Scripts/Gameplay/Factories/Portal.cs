using System;
using System.Collections;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Portal : MonoBehaviour
    {
        private EnemyFactory _enemyFactory;
        private Vector2Int[] _path;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _enemyFactory = EnemyFactory.Instance;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _path = new Vector2Int[]
            {
                new (4, 2),
                new (4, -3),
                new (-5, -3),
                new (-5, 1),
                new (-1, 1)
            };
        }

        private void Start()
        {
            StartCoroutine(Animation());
            StartCoroutine(MeleeOrkSpawnRoutine());
        }

        private IEnumerator Animation()
        {
            while (true)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                yield return new WaitForSeconds(0.5f);
            }
        }

        private IEnumerator MeleeOrkSpawnRoutine()
        {
            while (true)
            {
                var ork = EnemyFactory.Instance.CreateInstance(EEnemyType.MeleeOrk, transform.position);
                ork.Construct(_enemyFactory.NewID(), 10, 1, _path);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}