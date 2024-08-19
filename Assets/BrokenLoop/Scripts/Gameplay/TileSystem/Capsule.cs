using BrokenLoop.Gameplay;
using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class Capsule: MonoBehaviour
    {
        public int timeSpawnSecond = 5;
        public float timeSpeedPing = 5;
        public float sizeAlpha = 0.1f;
        public float minAlpha = 0.5f;
        public SpriteRenderer[] spriteRenderer;
        private void Start()
        {
            StartCoroutine(Ping());
            StartCoroutine(Timer());
        }
        IEnumerator Timer()
        {
            yield return new WaitForSeconds(timeSpawnSecond);
            //Вызываем метод из фабрики
            int tower = Random.Range(0, 2);
            BuildingsFactory.Instance.CreateInstance((EBuildingType)tower,gameObject.transform.position);
            Destroy(gameObject);
        }
        IEnumerator Ping()
        {
            while(gameObject.active)
            {
                yield return new WaitForSeconds(timeSpeedPing);
                foreach (var item in spriteRenderer)
                {
                    item.color = new Color(1, 1, 1, item.color.a - sizeAlpha);
                }
                if (spriteRenderer[3].color.a < minAlpha || spriteRenderer[3].color.a >= 1)
                {
                    sizeAlpha *= -1;
                }
            }
        }
    }
}
