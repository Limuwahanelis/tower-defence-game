using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public List<GameObject> path;
    private EnemyTilesCreator _pathCreator;
    private int _currentTargetTileIndex;
    public float epsilon = 0.001f;
    private Vector3 _targetPos;
    // Start is called before the first frame update
    void Start()
    {
        _pathCreator = EnemyTilesCreator.instance;
        path = _pathCreator.tiles;
        _currentTargetTileIndex = 1;
        transform.position = new Vector3(path[0].transform.position.x, 1f, path[0].transform.position.z);
        _targetPos = new Vector3(path[1].transform.position.x, 1f, path[1].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, _targetPos) <epsilon)
        {
            transform.position = _targetPos;
            _currentTargetTileIndex++;
            if (_currentTargetTileIndex < path.Count) _targetPos = new Vector3(path[_currentTargetTileIndex].transform.position.x, 1f, path[_currentTargetTileIndex].transform.position.z);
        }
    }
}
