using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyPathTile : MonoBehaviour
{
    public EnemyPath enemyPath;
    public GameObject[] neighbourTiles = new GameObject[4];
    public int tileIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTile(EnemyPath.TILE_DIR nextTileDirection, EnemyPathTile nextTile)
    {
        nextTile.GetComponent<EnemyPathTile>().enemyPath = enemyPath;

    }

    private void OnDestroy()
    {
        enemyPath.RemoveTileFromList(tileIndex);

    }

    void RepositionPath()
    {

    }
}
