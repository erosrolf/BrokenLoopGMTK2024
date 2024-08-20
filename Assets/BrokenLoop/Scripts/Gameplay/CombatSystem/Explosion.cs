using System.Collections;
using BrokenLoop.Gameplay;
using UnityEngine;

namespace BrokenLoop.Scripts.Gameplay.CombatSystem
{
    public class Explosion : MonoBehaviour
    {
        private float _lifetime = 0.6f;
        private Vector2 _damageBoxSize = new Vector2(0.6f, 0.6f);
        private int _damage = 10;
        

        private void Start()
        {
            StartCoroutine(AttackWithDelay(0.3f));
            Destroy(gameObject, _lifetime);
        }

        private IEnumerator AttackWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, _damageBoxSize, 0f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent<BaseBuilding>(out var building))
                {
                    if (building is IAttackable attackable)
                    {
                        attackable.Attack();
                    }
                }
                
                if (hitCollider.TryGetComponent<BaseEnemy>(out var baseEnemy))
                {
                    baseEnemy.TakeDamage(_damage);
                }
            }
        }
    }
}