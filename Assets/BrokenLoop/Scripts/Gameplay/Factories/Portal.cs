using System;
using System.Collections;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Portal : MonoBehaviour
    {
        private EnemyFactory _enemyFactory;
        private Vector2[] _path;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _enemyFactory = EnemyFactory.Instance;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _path = new Vector2[]
            {
                new (6.5f, -2.5f),
                new (7.5f, -2.5f),
                new (7.5f, -0.5f),
                new (6.5f, -0.5f),
                new (6.5f, 3.5f),
                new (7.5f, 3.5f),
                new (7.5f, 6.5f),
                new (4.5f, 6.5f),
                new (4.5f, 5.5f),
                new (3.5f, 5.5f),
                new (3.5f, 1.5f),
                new (0.5f, 1.5f),
                new (0.5f, -3.5f),
                new (-2.5f, -3.5f),
                new (-2.5f, -0.5f),
                new (-3.5f, -0.5f),
                new (-3.5f, 6.5f),
                new (-0.5f, 6.5f),
                new (-0.5f, 7.5f),
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
                ork.ConstructPath((_path));
                yield return new WaitForSeconds(2f);
            }
        }
    }
}