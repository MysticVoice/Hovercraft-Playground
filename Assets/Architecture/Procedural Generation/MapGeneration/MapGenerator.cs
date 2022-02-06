using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { NoiseMap, ColourMap, Mesh };
    public DrawMode drawMode;

    const int mapChunkSize = 241;
    [Range(0,6)]
    public int levelOfDetail;
    public float noiseScale;
    public float meshHeightMultiplier = 100;


    public AnimationCurve terrainAdjustments;
    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public ScriptableTerrainLayer[] terrainLayers;

    public GrayscaleMap noiseMap;
    public RenderMapToTexture display;
    public bool autoUpdate = true;

    public void GenerateMap()
    {
        noiseMap.map = Noise.GenerateNoiseMap(mapChunkSize,mapChunkSize,noiseScale,octaves,persistance,lacunarity,seed,offset);

        Color[] colourMap = new Color[mapChunkSize * mapChunkSize];

        for (int y = 0; y < mapChunkSize; y++)
        {
            for (int x = 0; x < mapChunkSize; x++)
            {
                float currentHeight = noiseMap.map[x, y];
                for (int i = 0; i < terrainLayers.Length; i++)
                {
                    if (currentHeight <= terrainLayers[i].GetHeight())
                    {
                        colourMap[y * mapChunkSize + x] = terrainLayers[i].GetColor();
                        break;
                    }
                }
                
            }
        }
        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap.map));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
        }
        else if (drawMode == DrawMode.Mesh)
        {

            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
            display.DrawMesh(MeshTerrainGenerator.GenerateMeshTerrain(noiseMap.map,meshHeightMultiplier,terrainAdjustments,levelOfDetail), TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
        }
    }

    private void OnValidate()
    {
        if (lacunarity < 1) lacunarity = 1;
        if (octaves < 0) octaves = 0;
    }
}