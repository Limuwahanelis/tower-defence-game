using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile2 : MonoBehaviour
{
    private int _selectedTower=0;
    private Vector3 _lastPos;
    public GameObject tilePrefab;
    public LayerMask mask;

    public Material towerNormalMaterial;
    public Material towerTransparentMaterial;
    [SerializeField]
    private GameObject[] _towers;
    public GameObject towerToPlacePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<_towers.Length;i++)
        {
            MeshRenderer[] meshes=_towers[i].GetComponentsInChildren<MeshRenderer>();
            for(int j=0;j<meshes.Length;j++)
            {
                meshes[j].material = towerTransparentMaterial;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity,mask))
        {
            int posX = (int)Mathf.Round(hit.point.x);
            int posZ = (int)Mathf.Round(hit.point.z);
            if(_lastPos.x!=posX || _lastPos.z!=posZ)
            {
                _lastPos.x = posX;
                _lastPos.z = posZ;
                tilePrefab.transform.position = new Vector3(posX, 0.001f, posZ);
                _towers[_selectedTower].transform.position = new Vector3(posX, _towers[_selectedTower].transform.position.y, posZ);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(towerToPlacePrefab, _towers[_selectedTower].transform.position, towerToPlacePrefab.transform.rotation);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, 20f * transform.TransformDirection(Vector3.forward));
    }

}
