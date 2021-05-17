using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyTile : MonoBehaviour
{
    public EnemyTilesCreator enemyPath;
    public GameObject[] neighbourTiles = new GameObject[4];
    public int tileIndex;

    public void AddTile(EnemyTilesCreator.TILE_DIR nextTileDirection, EnemyTile nextTile)
    {
        nextTile.GetComponent<EnemyTile>().enemyPath = enemyPath;

    }

    private void OnDestroy()
    {
        enemyPath.RemoveTileFromList(tileIndex);

    }
}
