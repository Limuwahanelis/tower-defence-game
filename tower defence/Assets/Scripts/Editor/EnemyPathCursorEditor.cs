//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(EnemyPathCursor))]
//public class EnemyPathCursorEditor : Editor
//{

//    private bool isDrawing = false;

//    void OnSceneGUI()
//    {
         
//        Event e = Event.current;

//        if (isDrawing)
//        {
//            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
//            RaycastHit hit;

//            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
//            {

//                EnemyPathCursor cursor = (EnemyPathCursor)target;
//                cursor.transform.position = new Vector3((int)Mathf.Round(hit.point.x), cursor.transform.position.y, (int)Mathf.Round(hit.point.z));
//                //PlaceObject(myPos);
//                if (Input.GetMouseButton(0))
//                {

//                }
//            }
//        }
//    }

//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();
//        //EnemyTilesCreator path = (EnemyTilesCreator)target;
//        if (GUILayout.Button("switch drawing"))
//        {
//            isDrawing = !isDrawing;
//        }
//    }
//    private void OnEnable()
//    {
//        Tools.current=Tool.Custom;
//    }
//}
