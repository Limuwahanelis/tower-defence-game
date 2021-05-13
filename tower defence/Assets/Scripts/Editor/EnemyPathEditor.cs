using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyTilesCreator))]
public class EnemyPathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EnemyTilesCreator path = (EnemyTilesCreator)target;
        if (GUILayout.Button("Add next tile"))
        {
            path.AddTile();
        }
    }
}
