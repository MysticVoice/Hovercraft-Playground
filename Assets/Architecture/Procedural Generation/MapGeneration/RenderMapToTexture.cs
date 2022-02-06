using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMapToTexture : MonoBehaviour
{
    public GrayscaleMap map;
    public RenderTexture rt;
    public MeshFilter meshFilter;
    public void DrawTexture(Texture2D texture)
    {
        Graphics.Blit(texture,rt);
    }

    public void DrawMesh(MeshData meshData, Texture2D texture)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        Graphics.Blit(texture, rt);
    }
}
