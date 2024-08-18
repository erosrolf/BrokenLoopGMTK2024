using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovebleTile
{
    public bool Push(Vector3Int direction);
}