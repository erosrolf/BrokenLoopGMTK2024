using UnityEngine;

namespace Assets.BrokenLoop.Scripts.Gameplay.TileSystem
{
    public class TestClass: MonoBehaviour
    {
        MoveObjectOnTilemap move;
        bool t=false;
        private void Start()
        {
            move = new MoveObjectOnTilemap(gameObject);

            
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.W)) {
                t=move.Push(new Vector3Int(0, 1, 0));
                Debug.Log($"{gameObject.transform.position + new Vector3(0,1,0)}");
               //foreach (var item in TileResourceForMove.Instance.GetListMoveTile())
               //{
               //    Debug.Log(item);
               //}
            }
            else if(Input.GetKeyDown(KeyCode.S)) {
                t = move.Push(new(0, -1, 0));

                Debug.Log($"s {t} {gameObject.transform.position}");

            }
            else if (Input.GetKeyDown(KeyCode.D)) {
                t = move.Push(new(1, 0, 0));
                Debug.Log($"d {t} {gameObject.transform.position}");

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                t = move.Push(new(-1, 0, 0));
                Debug.Log($"a {t} {gameObject.transform.position}");

            }
        }
    }
}
