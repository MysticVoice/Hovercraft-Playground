using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Noise Map",menuName ="Map Generation/Noise Map")]
public class NoiseMap : ScriptableObject
{
    [SerializeField]
    public float[,] map;
}
