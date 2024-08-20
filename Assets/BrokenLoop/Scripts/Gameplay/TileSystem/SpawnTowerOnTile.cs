using System.Collections;
using UnityEngine;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class SpawnTowerOnTile : MonoBehaviour
    {
        
        public GameObject capsule;
        public int timeSpawnCapsule = 10;
        private void Start()
        {
            StartCoroutine(Spawner());
        }


        IEnumerator Spawner()
        {
            TileResourceForMove tileResource = TileResourceForMove.Instance;
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(timeSpawnCapsule);
                int i = Random.Range(0, tileResource.GetListMoveTile().Count);
                Instantiate(capsule, tileResource.GetListMoveTile()[i],Quaternion.identity);
            }
        }
    }
}
