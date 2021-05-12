using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public static GridGenerator instance;
    public GameObject quadPrefab;

    public Material normalMaterial;
    public Material highlightMaterial;

    public int numberOfRows;
    public int numberOfColumns;

    public GameObject grid;
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        } else if(instance!=this)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateGrid()
    {
        if(grid==null)
        {
            grid = new GameObject();
            grid.name = "Grid";
        }
        float xPos = 0;
        float yPos = 0;
        for (int  i = 0;i<numberOfColumns; i++)
        {
            
            for (int j=0;j<numberOfRows;j++)
            {
                GameObject quad= Instantiate(quadPrefab,quadPrefab.transform.rotation*new Vector3(xPos,yPos,0) ,quadPrefab.transform.rotation, grid.transform);
                quad.GetComponent<MeshRenderer>().material = normalMaterial;
                yPos -= quadPrefab.transform.localScale.y;
            }
            yPos = 0;
            xPos += quadPrefab.transform.localScale.x;
        }
    }
}
