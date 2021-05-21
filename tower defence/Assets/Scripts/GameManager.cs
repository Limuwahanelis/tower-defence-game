using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int _wave;
    public int[] enemiesPerWave;
    public float spawnDelay;
    public Transform spawnPos;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(this);
        }
        _wave = 0;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {

        for (int i = 0; i < enemiesPerWave[_wave]; i++)
        {
            Instantiate(enemyPrefab, spawnPos.transform.position, enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
