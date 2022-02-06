using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Type",menuName = "Map Generation/Terrain Type")]
public class TerrainType : ScriptableObject
{
    public string description;
    public Color color;

    public Color GetColor()
    {
        return color;
    }
}
