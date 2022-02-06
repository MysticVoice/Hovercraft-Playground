using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator generator = (MapGenerator)target;
        base.OnInspectorGUI();
        if(GUI.changed && generator.autoUpdate)
        {
            generator.GenerateMap();
        }
        if(GUILayout.Button("Generate"))
        {
            generator.GenerateMap();
        }
    }
}
