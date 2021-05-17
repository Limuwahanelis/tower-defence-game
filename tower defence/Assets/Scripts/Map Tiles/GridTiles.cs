using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTiles : MonoBehaviour
{
    [SerializeField]
    Vector3 _objectScale;
    [SerializeField]
    GameObject _terrain;
    [SerializeField]
    Material _gridMaterial;
    [SerializeField]
    GameObject _grid;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnValidate()
    {
        if(_objectScale!=transform.localScale)
        {
            //transform.localScale=_objectScale;
            _terrain.transform.localScale = _objectScale;
            _grid.transform.localScale = _objectScale;
            _gridMaterial.mainTextureScale = new Vector2(_objectScale.x, _objectScale.z);
        }
    }
}
