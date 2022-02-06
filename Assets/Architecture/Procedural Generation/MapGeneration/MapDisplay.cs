using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public NoiseMap map;
    public RenderTexture rt;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    public void DrawNoiseMap(float[,] noisemap)
    {
        int width = noisemap.GetLength(0);
        int height = noisemap.GetLength(1);
        Color[] colourMap = new Color[width * height];
        Texture2D texture = new Texture2D(width, height);
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noisemap[x, y]);
            }
        }
        texture.SetPixels(colourMap);
        texture.Apply();
        Graphics.Blit(texture,rt);
    }
}
