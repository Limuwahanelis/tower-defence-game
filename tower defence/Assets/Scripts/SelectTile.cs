using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour
{
    private GameObject _selectedTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            if(_selectedTile!= hit.transform.gameObject && _selectedTile!=null)
            {
                _selectedTile.GetComponent<MeshRenderer>().material= GridGenerator.instance.normalMaterial;
            }
            _selectedTile = hit.transform.gameObject;
            _selectedTile.GetComponent<MeshRenderer>().material = GridGenerator.instance.highlightMaterial;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, 20f * transform.TransformDirection(Vector3.forward));
    }

    public GameObject GetSelectedTile()
    {
        return _selectedTile;
    }
}
