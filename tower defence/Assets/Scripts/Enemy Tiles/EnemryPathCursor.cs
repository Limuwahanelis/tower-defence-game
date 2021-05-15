using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemryPathCursor : MonoBehaviour
{
    private EnemyTilesCreator pathCreator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3((int)Mathf.Round(transform.position.x), transform.position.y, (int)Mathf.Round(transform.position.z));
        pathCreator.startingPoint = new Vector3(transform.position.x,pathCreator.startingPoint.y, transform.position.z) ;
    }

    private void OnEnable()
    {
        pathCreator = FindObjectOfType<EnemyTilesCreator>();
    }


}
