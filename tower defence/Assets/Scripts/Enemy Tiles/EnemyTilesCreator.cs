using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyTilesCreator : MonoBehaviour
{
    public enum TILE_DIR
    {
        LEFT,
        UP,
        RIGHT,
        DOWN
    }

    public LayerMask terrainMask;
    public Material currentSelectedTileMat;
    public Material tileMat;
    public GameObject tilePrefab;
    public GameObject path;
    public EnemyPathCursor cursor;
    public static EnemyTilesCreator instance;

    public int currentSelectedTile=0;
    public int numberOfTiles = 0;
    public Vector3 startingPoint;
    public List<GameObject> tiles=new List<GameObject>();

    public bool isDrawingEnemyTiles = false;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        } else if(instance!=this)
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void AddTile(Transform cursorPos)
    {
        GameObject nextTile = null;
        if (path == null)
        {
            path = new GameObject("Tiles");
        }
        if (tiles.Find((tile) => tile.transform.position == new Vector3(cursorPos.transform.position.x, cursor.transform.position.y, cursorPos.transform.position.z))) return;
        nextTile = Instantiate(tilePrefab, cursorPos.position, tilePrefab.transform.rotation, path.transform);
        tiles.Add(nextTile);
        nextTile.GetComponent<EnemyTile>().enemyPath = this;
        nextTile.GetComponent<EnemyTile>().tileIndex = numberOfTiles;
        nextTile.name = "Tile" + numberOfTiles;
        SetNeighbourTiles(nextTile);
        numberOfTiles++;

    }

    private void SetNeighbourTiles(GameObject tileToSetNeighbours)
    {
        GameObject tile = tiles.Find((neighbourTile) => (neighbourTile.transform.position - tileToSetNeighbours.transform.position).x == -1 && (tileToSetNeighbours.transform.position.z == neighbourTile.transform.position.z));
        if (tile != null)
        {
            SetNeighbourTilesLR(tileToSetNeighbours, tile);
        }
        tile = tiles.Find((neighbourTile) => (neighbourTile.transform.position - tileToSetNeighbours.transform.position).x == 1 && (tileToSetNeighbours.transform.position.z == neighbourTile.transform.position.z));
        if (tile != null)
        {
            SetNeighbourTilesLR(tile, tileToSetNeighbours);
        }
        tile = tiles.Find((neighbourTile) => (neighbourTile.transform.position - tileToSetNeighbours.transform.position).z == -1 && (tileToSetNeighbours.transform.position.x == neighbourTile.transform.position.x));
        if (tile != null)
        {
            SetNeighbourTilesUD(tileToSetNeighbours, tile);
        }
        tile = tiles.Find((neighbourTile) => (neighbourTile.transform.position - tileToSetNeighbours.transform.position).z == 1 && (tileToSetNeighbours.transform.position.x== neighbourTile.transform.position.x));
        if (tile != null)
        {
            SetNeighbourTilesUD(tile, tileToSetNeighbours);
        }
    }
    private void SetNeighbourTilesLR(GameObject tile1, GameObject tile2)
    {
        tile1.GetComponent<EnemyTile>().neighbourTiles[(int)TILE_DIR.LEFT] = tile2;
        tile2.GetComponent<EnemyTile>().neighbourTiles[(int)TILE_DIR.RIGHT] = tile1;
    }
    private void SetNeighbourTilesUD(GameObject tile1, GameObject tile2)
    {
        tile1.GetComponent<EnemyTile>().neighbourTiles[(int)TILE_DIR.DOWN] = tile2;
        tile2.GetComponent<EnemyTile>().neighbourTiles[(int)TILE_DIR.UP] = tile1;
    }

    public void RemoveTileFromList(int tileIndex)
    {
        
        tiles.RemoveAt(tileIndex);
        numberOfTiles--;
        for (int i = tileIndex;i<tiles.Count;i++)
        {
            tiles[i].GetComponent<EnemyTile>().tileIndex = i;
            tiles[i].name= "Tile" + i;
        }
    }
}
