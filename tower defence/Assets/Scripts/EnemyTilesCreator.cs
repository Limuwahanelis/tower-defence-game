using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyTilesCreator : MonoBehaviour
{
    public Material currentSelectedTileMat;
    public Material tileMat;
    public GameObject tilePrefab;
    public GameObject path;
    public static EnemyTilesCreator instance;
    public enum TILE_DIR
    {
        LEFT,
        UP,
        RIGHT,
        DOWN
    }
    public TILE_DIR nextTileDirection;

    public int currentSelectedTile=0;
    public int lastTileIndex = 0;
    public Vector3 startingPoint;
    public List<GameObject> tiles=new List<GameObject>();

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
    public void AddTile()
    {
        GameObject nextTile=null;
        if (path == null)
        {
            path = new GameObject("Path");
            nextTile = Instantiate(tilePrefab, startingPoint, tilePrefab.transform.rotation, path.transform);
            tiles.Add(nextTile);
            nextTile.GetComponent<EnemyTile>().enemyPath = this;
            nextTile.GetComponent<EnemyTile>().tileIndex = lastTileIndex;
            nextTile.name = "Tile" + lastTileIndex;
            return;
        }
        if(tiles.Count==0)
        {
            nextTile = Instantiate(tilePrefab, startingPoint, tilePrefab.transform.rotation, path.transform);
            tiles.Add(nextTile);
            nextTile.GetComponent<EnemyTile>().enemyPath = this;
            nextTile.GetComponent<EnemyTile>().tileIndex = lastTileIndex;
            nextTile.name = "Tile" + lastTileIndex;
            return;
        }
        

        if (tiles[lastTileIndex].GetComponent<EnemyTile>().neighbourTiles[(int)nextTileDirection] != null) return;

        switch (nextTileDirection)
        {
            case TILE_DIR.LEFT:
                {
                    nextTile = Instantiate(tilePrefab,tiles[lastTileIndex].transform.position + new Vector3(-1f * transform.localScale.x, 0, 0), tilePrefab.transform.rotation, path.transform);
                    nextTile.GetComponent<EnemyTile>().neighbourTiles[(int)EnemyTilesCreator.TILE_DIR.RIGHT] = tiles[lastTileIndex];
                    

                    break;
                }
            case TILE_DIR.UP:
                {
                    nextTile = Instantiate(tilePrefab, tiles[lastTileIndex].transform.position + new Vector3(0, 0, 1f * transform.localScale.z), tilePrefab.transform.rotation, path.transform);
                    nextTile.GetComponent<EnemyTile>().neighbourTiles[(int)EnemyTilesCreator.TILE_DIR.DOWN] = tiles[lastTileIndex];
                    break;
                }
            case TILE_DIR.RIGHT:
                {
                    nextTile = Instantiate(tilePrefab, tiles[lastTileIndex].transform.position + new Vector3(1f * transform.localScale.x, 0, 0), tilePrefab.transform.rotation, path.transform);
                    nextTile.GetComponent<EnemyTile>().neighbourTiles[(int)EnemyTilesCreator.TILE_DIR.LEFT] = tiles[lastTileIndex];
                    break;
                }
            case TILE_DIR.DOWN:
                {
                    nextTile = Instantiate(tilePrefab, tiles[lastTileIndex].transform.position + new Vector3(0, 0, -1f * transform.localScale.z), tilePrefab.transform.rotation, path.transform);
                    nextTile.GetComponent<EnemyTile>().neighbourTiles[(int)EnemyTilesCreator.TILE_DIR.UP] = tiles[lastTileIndex];
                    break;
                }
        }
        //nextTile.GetComponent<EnemyPathTile>().enemyPath = enemyPath;
        tiles[lastTileIndex].GetComponent<EnemyTile>().neighbourTiles[(int)nextTileDirection] = nextTile;
        tiles.Add(nextTile);
        lastTileIndex++;
        nextTile.GetComponent<EnemyTile>().tileIndex = lastTileIndex;
        nextTile.GetComponent<EnemyTile>().enemyPath = this;
        nextTile.name = "Tile" + lastTileIndex;
        //tiles[currentSelectedTile].GetComponent<EnemyPathTile>().AddTile(nextTileDirection);
        //tiles[currentSelectedTile].GetComponent<EnemyPathTile>().AddTile(nextTileDirection);
    }

    private void OnValidate()
    {
        //if()
    }

    public void RemoveTileFromList(int tileIndex)
    {
        
        tiles.RemoveAt(tileIndex);
        lastTileIndex--;
        for (int i = tileIndex;i<tiles.Count;i++)
        {
            tiles[i].GetComponent<EnemyTile>().tileIndex = i;
            tiles[i].name= "Tile" + i;
        }
    }
}
