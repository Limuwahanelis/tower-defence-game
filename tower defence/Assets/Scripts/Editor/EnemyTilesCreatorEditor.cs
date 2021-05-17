using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyTilesCreator))]
public class EnemyTilesCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EnemyTilesCreator path = (EnemyTilesCreator)target;
        //if (GUILayout.Button("Add next tile"))
        //{
        //    path.AddTile();
        //}
        if (GUILayout.Button("switch drawing"))
        {
            isDrawing = !isDrawing;
        }
    }


    private bool isDrawing = false;

    void OnSceneGUI()
    {

        Event e = Event.current;


        if (isDrawing)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            EnemyTilesCreator creator = (EnemyTilesCreator)target;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                EnemyPathCursor cursor = ((EnemyTilesCreator)target).cursor;
                
                cursor.transform.position = new Vector3((int)Mathf.Round(hit.point.x), cursor.transform.position.y, (int)Mathf.Round(hit.point.z));
                    int controlID = GUIUtility.GetControlID(FocusType.Passive);
                    switch (Event.current.GetTypeForControl(controlID))
                    {
                    case EventType.MouseDown:
                        {
                            creator.AddTile(cursor.transform);
                            GUIUtility.hotControl = controlID;
                            Event.current.Use();
                            break;
                        }
                    case EventType.MouseDrag:
                        {
                            creator.AddTile(cursor.transform);
                            GUIUtility.hotControl = controlID;
                            Event.current.Use();
                            break;
                        }

                        case EventType.MouseUp:
                            GUIUtility.hotControl = 0;
                            Event.current.Use();
                            break;
                    }
            }

        }
        
    }
    private void OnEnable()
    {
        Tools.current = Tool.Custom;
    }
}
