using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathCreator : MonoBehaviour
{
    [System.Serializable]
    public class EnemyTilesWrapper
    {
        public List<EnemyTile> keyTiles;
    }
    public static EnemyPathCreator instance;
    public List<EnemyTilesWrapper> enemyPaths = new List<EnemyTilesWrapper>();
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
