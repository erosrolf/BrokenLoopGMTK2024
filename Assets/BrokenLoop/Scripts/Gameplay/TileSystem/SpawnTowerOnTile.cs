using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

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
        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.W))
        //    {
        //        Push(new Vector3Int(0,1,0));
        //    }
        //    else if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        Push(new Vector3Int(0, -1, 0));
        //    }
        //    else if (Input.GetKeyDown(KeyCode.D))
        //    {
        //        Push(new Vector3Int(1, 0, 0));
        //    }
        //    else if (Input.GetKeyDown(KeyCode.A))
        //    {
        //        Push(new Vector3Int(-1, 0, 0));
        //    }
        //    if(Input.GetKeyDown(KeyCode.Space))
        //    {
        //        RefreshGround();
        //    }
        //}
       //public bool Push(Vector3Int direction)
       //{
       //    var newPosition = _gameObject.transform.position + direction;
       //    var canMove = filledCellWorldPositions.Contains(newPosition);
       //    if (canMove)
       //    {
       //        _gameObject.transform.position = newPosition;
       //        return true;
       //    }
       //    return false;
       //}
    }
}
