using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour,IDamagable
{
    public EnemyStats stats;
    public Slider slider;
    [SerializeField]
    private int _pathIndex;
    private int _dmg;
    private int _health;
    public float speed;
    private List<EnemyTile> _path;
    private EnemyPathCreator _pathCreator;
    private int _currentTargetTileIndex;
    public float epsilon = 0.001f;
    private Vector3 _targetPos;
    private Vector3 _movementDirection;
    private Vector3 _futurePos;
    private Vector3 _targetPosDirection;
    public GameObject tester;
    private bool _change=false;
    // Start is called before the first frame update
    void Start()
    {
        SetStats();
        SetSlider();
        
        _pathCreator = EnemyPathCreator.instance;
        _path = _pathCreator.enemyPaths[_pathIndex].keyTiles;
        _currentTargetTileIndex = 1;
        transform.position = new Vector3(_path[0].transform.position.x, 0.55f, _path[0].transform.position.z);
        _futurePos = transform.position+ Vector3.forward * speed;
        _targetPos = new Vector3(_path[1].transform.position.x, 0.55f, _path[1].transform.position.z);
        _movementDirection = _targetPos - transform.position;
        _targetPosDirection = _targetPos - transform.position;
        transform.LookAt(_targetPos, Vector3.up);
        
        CalculateDirectionVector();
        
    }

    // Update is called once per frame
    void Update()
    {
        tester.transform.position = _futurePos;
        transform.position= Vector3.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);
        CalculateDirectionVector();
        if(Vector3.Distance(transform.position, _targetPos) <epsilon)
        {
            
            transform.position = _targetPos;
            _currentTargetTileIndex++;
            transform.LookAt(new Vector3(_path[_currentTargetTileIndex].transform.position.x, 0.55f, _path[_currentTargetTileIndex].transform.position.z), Vector3.up);
            if (_currentTargetTileIndex < _path.Count) _targetPos = new Vector3(_path[_currentTargetTileIndex].transform.position.x, 0.55f, _path[_currentTargetTileIndex].transform.position.z);
        }
        //Debug.Log(GetEnemyDirection());
    }

    public Vector3 GetEnemyDirection()
    {
        Vector3 toRet = _movementDirection;
        toRet.Normalize();
        //toRet = new Vector3(0, toRet.y, toRet.z);
        return toRet;
    }

    public Vector3 GetDistanceFromTurnPoint()
    {
        Vector3 tmp = transform.position - _path[_currentTargetTileIndex].transform.position;
        return new Vector3(Mathf.Abs(tmp.x), Mathf.Abs(tmp.y), Mathf.Abs(tmp.z));
    }

    public Vector3 GetDirectionToNextTurn()
    {
        return Vector3.Normalize( _path[_currentTargetTileIndex+1].transform.position - _path[_currentTargetTileIndex].transform.position);
    }
    public void TakeDamage(int dmg)
    {
        _health -= dmg;
        slider.value = _health;
        //Debug.Log("dssd");

    }

    private void SetStats()
    {
        speed = stats.movementspeed;
        _dmg = stats.dmgToNexus;
        _health = stats.maxHealth;
    }

    private void SetSlider()
    {
        slider.maxValue = stats.maxHealth;
        slider.value = stats.maxHealth;
    }

    private void CalculateDirectionVector()
    {
        if(Vector3.Distance(transform.position,_targetPos)<speed)
        {
            Vector3 vec0 = transform.position - _targetPos;
            //Debug.Log("vec0 " + vec0);
            Vector3 vec1 = (_targetPos - transform.position);//.normalized;
            //Debug.Log("vec1 " + vec1);
            vec1 = Vector3.Normalize(new Vector3(vec1.x, 0.0f, vec1.z));
            //Debug.Log("vec12 " + vec1);
            Vector3 nextTar = Vector3.Normalize(_path[_currentTargetTileIndex + 1].transform.position - _targetPos);
            //Debug.Log("vecNect " + nextTar);
            Vector3 vec2 = _targetPos + new Vector3((speed - vec0.z) * nextTar.x, 0.0f, (speed - vec0.x) * nextTar.z);
            //Debug.Log("TOAdd " + new Vector3((speed - vec0.z) * nextTar.x, 0.0f, (speed - vec0.x) * nextTar.z));
            //Debug.Log("vec2 " + vec2);
            _futurePos = vec2;
            //_futurePos = new Vector3((_targetPos - transform.position).x, 0.55f, (_targetPos - transform.position).z);
        }
        else
        {
            _futurePos = transform.position + transform.forward * speed;
        }
        _movementDirection = _futurePos - transform.position;
        //if()
        //Debug.Log(Vector3.Distance(_futurePos, _targetPos));
        //if (Vector3.Distance(_futurePos, _targetPos) < 0.1)
        //{
        //    _futurePos = new Vector3(_targetPos.x, _futurePos.y, _targetPos.z);
        //    _change = true;
        //    //if (Vector3.Distance())
        //}
        //if(_change)
        //{

        //}
        //else
        //{
            
        //}
        ////if(_change)
        ////{
        ////    if (Mathf.Abs(_movementDirection.x) == 1 || Mathf.Abs(_movementDirection.z) == 1) _change = false;
        ////}
        
        ////Debug.Log(_movementDirection);
    }    
}
