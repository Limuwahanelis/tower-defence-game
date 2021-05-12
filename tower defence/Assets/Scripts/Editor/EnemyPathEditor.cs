using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyPath))]
public class EnemyPathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EnemyPath path = (EnemyPath)target;
        if (GUILayout.Button("Add next tile"))
        {
            path.AddTile();
        }
    }
}
