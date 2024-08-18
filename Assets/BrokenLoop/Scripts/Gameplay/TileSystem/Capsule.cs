using System.Collections;
using UnityEngine;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class Capsule: MonoBehaviour
    {
        public int timeSpawnSecond = 5;

        private void Start()
        {
            StartCoroutine(Timer());
        }
        IEnumerator Timer()
        {
                yield return new WaitForSeconds(timeSpawnSecond);
                //Вызываем метод из фабрики
                Destroy(gameObject);
        }
    }
}
