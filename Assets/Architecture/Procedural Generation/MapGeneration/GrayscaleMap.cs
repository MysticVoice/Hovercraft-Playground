using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Grayscale Map",menuName ="Map Generation/Grayscale Map")]
public class GrayscaleMap : ScriptableObject
{
    [SerializeField]
    public float[,] map;
}
