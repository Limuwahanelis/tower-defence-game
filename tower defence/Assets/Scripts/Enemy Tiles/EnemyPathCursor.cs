using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyPathCursor : MonoBehaviour
{
    private Vector3 _lastPos;
    private EnemyTilesCreator pathCreator;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //if (Camera.current != null)
            
        //    Ray ray = ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //    {
        //        int posX = (int)Mathf.Round(hit.point.x);
        //        int posZ = (int)Mathf.Round(hit.point.z);
        //        if (_lastPos.x != posX || _lastPos.z != posZ)
        //        {
        //            _lastPos.x = posX;
        //            _lastPos.z = posZ;
        //            transform.position = new Vector3(posX, 0.001f, posZ);
        //        }
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            //Instantiate(towerToPlacePrefab, _towers[_selectedTower].transform.position, towerToPlacePrefab.transform.rotation);
        //        }
        //    }
        //transform.position = new Vector3((int)Mathf.Round(transform.position.x), transform.position.y, (int)Mathf.Round(transform.position.z));
        //pathCreator.startingPoint = new Vector3(transform.position.x,pathCreator.startingPoint.y, transform.position.z) ;
    }

    private void OnEnable()
    {
        pathCreator = FindObjectOfType<EnemyTilesCreator>();
    }


}
