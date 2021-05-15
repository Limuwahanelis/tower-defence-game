using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTiles : MonoBehaviour
{

    [SerializeField]
    GameObject _terrain;
    [SerializeField]
    Vector3 _objectScale;
    [SerializeField]
    Material _gridMaterial;
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
            transform.localScale=_objectScale;
            _terrain.transform.localScale = _objectScale;
            _gridMaterial.mainTextureScale = new Vector2(_objectScale.x, _objectScale.z);
        }
    }
}
