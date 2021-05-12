using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test))]
public class TestEditor : Editor
{

    static void Crteate()
    {
        GameObject go = new GameObject();
        go.name = "dd";
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Test test = (Test)target;
        if(GUILayout.Button("ss"))
        {
            test.ssss();
        }
    }
}
