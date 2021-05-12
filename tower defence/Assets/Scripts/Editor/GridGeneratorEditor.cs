using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridGenerator generator = (GridGenerator)target;
        if (GUILayout.Button("Create grid"))
        {
            generator.CreateGrid();
        }
    }
}
