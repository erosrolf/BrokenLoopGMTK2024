using Assets.BrokenLoop.Scripts.Gameplay.TileSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonoMove: MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap tilemapObject;
    public Camera camera;
    public GameObject tree;
    MoveObjectOnTilemap moveObjectOnTile;
    SetObjectOnTile setObjectOnTile;
    private void Start()
    {
        moveObjectOnTile = new(tilemap,tree);
        setObjectOnTile = new(tilemap, camera);
        Debug.Log($"H {camera.pixelHeight} and W {camera.pixelWidth}"); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveObjectOnTile.Push(new(0,1,0));
            Debug.Log($"W");
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            moveObjectOnTile.Push(new(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
            moveObjectOnTile.Push(new(1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            moveObjectOnTile.Push(new(-1, 0, 0));
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            var objectSpawn = Instantiate(tree);
            setObjectOnTile.SetObjectOnMapRandom(objectSpawn);
            Debug.Log(setObjectOnTile.GetRandomPointCamera());
        }
    }
}