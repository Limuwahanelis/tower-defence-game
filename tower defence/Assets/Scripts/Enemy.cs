using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Simple Enemy")]
public class Enemy : MonoBehaviour
{
    public EnemyStats stats;

    [SerializeField]
    private int _pathIndex;
    private int _dmg;
    private int _health;
    public float speed;
    private List<EnemyTile> _path;
    private EnemyPathCreator _pathCreator;
    public EnemyTile spawnPos;
    private int _currentTargetTileIndex;
    public float epsilon = 0.001f;
    private Vector3 _targetPos;
    // Start is called before the first frame update
    void Start()
    {
        speed = stats.movementspeed;
        _dmg = stats.dmgToNexus;
        _health = stats.maxHealth;
        _pathCreator = EnemyPathCreator.instance;
        _path = _pathCreator.enemyPaths[_pathIndex].keyTiles;
        _currentTargetTileIndex = 1;
        transform.position = new Vector3(_path[0].transform.position.x, 1f, _path[0].transform.position.z);
        _targetPos = new Vector3(_path[1].transform.position.x, 1f, _path[1].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, _targetPos) <epsilon)
        {
            transform.position = _targetPos;
            _currentTargetTileIndex++;
            if (_currentTargetTileIndex < _path.Count) _targetPos = new Vector3(_path[_currentTargetTileIndex].transform.position.x, 1f, _path[_currentTargetTileIndex].transform.position.z);
        }
        //Debug.Log(GetEnemyDirection());
    }

    public Vector3 GetEnemyDirection()
    {
        return (_targetPos-transform.position).normalized;
    }

}
