using Assets.BrokenLoop.Scripts.Gameplay.TileSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnTowerOnTile: MonoBehaviour
{
    public Tilemap tilemap;
    public Camera camera;
    PositionOnTileCamera setObjectOnTile;
    public GameObject capsulePredab;
    public int SpawnSecond = 2;
    private void Start()
    {
        setObjectOnTile = new(tilemap, camera);
        StartCoroutine(Spawner());
    }
     
    IEnumerator Spawner()
    {
        while(gameObject.activeSelf)
        {
            yield return new WaitForSeconds(SpawnSecond);
            CreateCapsule();
        }
    }
    private void CreateCapsule() 
    {
        var objectSpawn = Instantiate(capsulePredab);
        setObjectOnTile.SetObjectOnMapRandom(objectSpawn);
    }
}