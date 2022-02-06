using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Terrain Layer",menuName = "Map Generation/Scriptable Terrain Layer")]
public class ScriptableTerrainLayer : ScriptableObject
{
    public TerrainType type;
    public float height;
    public Color GetColor()
    {
        return type.GetColor();
    }

    public float GetHeight()
    {
        return height;
    }
}
