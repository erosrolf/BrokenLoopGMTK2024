using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GroundDetect : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject game;
    private List<Vector3> filledCellWorldPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        // RefreshGround();
        FindRoad();
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        foreach (var item in filledCellWorldPositions)
        {
            yield return new WaitForSeconds(1);
            game.transform.position = item;
        }
    }

    public void RefreshGround()
    {
        List<Vector3> buffer = new List<Vector3>();
        BoundsInt bounds = tilemap.cellBounds;
        foreach (var position in bounds.allPositionsWithin)
        {
            var tile = tilemap.GetTile<RuleTile>(position);
            if (tile != null)
            {
                Vector3 worldPosition = tilemap.GetCellCenterWorld(position);
                buffer.Add(worldPosition);  
            }
        }
        filledCellWorldPositions.Clear();
        filledCellWorldPositions.AddRange(buffer);
        Debug.Log(filledCellWorldPositions.Count);
    }

    private void FindRoad()
    {
        filledCellWorldPositions.Add(game.transform.position);
        List<Vector3> buffer = new List<Vector3>();

        Vector3Int tilePos = tilemap.WorldToCell(game.transform.position);

        bool isRoad = true;
        Vector3 direction;
        do
        {
            var tile = tilemap.GetTile<RuleTile>(tilePos);
            if (tile != null)
            {
                var leftTile = new Vector3Int(tilePos.x - 1, tilePos.y, tilePos.z);
                var rightTile = new Vector3Int(tilePos.x + 1, tilePos.y, tilePos.z);
                var topTile = new Vector3Int(tilePos.x, tilePos.y + 1, tilePos.z);
                var botTile = new Vector3Int(tilePos.x, tilePos.y - 1, tilePos.z);
                if (tilemap.GetTile<RuleTile>(leftTile) && !buffer.Contains(leftTile))
                {
                    direction = tilemap.GetCellCenterWorld(leftTile);
                    filledCellWorldPositions.Add(direction);
                    buffer.Add(leftTile);
                    tilePos = leftTile;
                }
                else if (tilemap.GetTile<RuleTile>(rightTile) && !buffer.Contains(rightTile))
                {
                    direction = tilemap.GetCellCenterWorld(rightTile);
                    filledCellWorldPositions.Add(direction);
                    tilePos = rightTile;
                    buffer.Add(rightTile);
                }
                else if (tilemap.GetTile<RuleTile>(topTile) && !buffer.Contains(topTile))
                {
                    direction = tilemap.GetCellCenterWorld(topTile);
                    filledCellWorldPositions.Add(direction);
                    tilePos = topTile;
                    buffer.Add(topTile);
                }
                else if (tilemap.GetTile<RuleTile>(botTile) && !buffer.Contains(botTile))
                {
                    direction = tilemap.GetCellCenterWorld(botTile);
                    filledCellWorldPositions.Add(direction);
                    tilePos = botTile;
                    buffer.Add(botTile);
                }
                else
                {
                    isRoad = false;
                }
            }
            else
            {
                isRoad = false;
            }
        }while (isRoad);
        
    }
}
