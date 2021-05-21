using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerStats stats;

    public GameObject attackRangeIndicator;
    public GameObject mainBody;
    public GameObject turret;
    public GameObject missilePrefab;

    public Transform missileSpawnPos;

    [SerializeField]
    private SphereCollider _col;
    private List<Enemy> _targetsInRange=new List<Enemy>();
    private Enemy _currentTarget;

    private bool onCoolDown = false;
    private bool _attack = true;
    GameObject tmp;
    // Start is called before the first frame update
    void Start()
    {
        
        attackRangeIndicator.transform.localScale = new Vector3(stats.attackRange, stats.attackRange, attackRangeIndicator.transform.localScale.z);
        _col.radius = attackRangeIndicator.transform.localScale.x / 2;
        //turret.transform.forward = new Vector3(0, 1, 0);

    }

    // Update is called once per frame 
    void Update()
    {
        
        if (_currentTarget != null)
        {
            turret.transform.LookAt(CalculateInterceptPoint());
            if (_attack)
            {

                StartCoroutine(CoolDownCor());
            }
            if(!_attack)
            {

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _targetsInRange.Add(other.gameObject.GetComponent<Enemy>());
        if (_targetsInRange.Count == 1) _currentTarget = other.gameObject.GetComponent<Enemy>();
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        _targetsInRange.Remove(enemy);
        if (_currentTarget = enemy) _currentTarget = null;
    }
    IEnumerator CoolDownCor()
    {
        if (!_attack) yield break;
        _attack = false;
        tmp = Instantiate(missilePrefab, missileSpawnPos.transform.position, missileSpawnPos.transform.rotation);
        tmp.GetComponent<Missile>().speed = stats.missileSpeed;
        yield return new WaitForSeconds(1/stats.attackRate);
        _attack = true;
    }
    Vector3 CalculateInterceptPoint()
    {
        // === variables you need ===
        //how fast our shots move
        float shotSpeed= stats.missileSpeed;
        //objects

        // === derived variables ===
        //positions
        Vector3 shooterPosition = missileSpawnPos.position;
        Vector3 targetPosition = _currentTarget.transform.position;
        //velocities
        Vector3 shooterVelocity = Vector3.zero;
        Vector3 targetVelocity = _currentTarget.speed * _currentTarget.GetEnemyDirection();

        //calculate intercept
        return FirstOrderIntercept
        (
            shooterPosition,
            shooterVelocity,
            shotSpeed,
            targetPosition,
            targetVelocity
        );
    }

    Vector3 FirstOrderIntercept(Vector3 shooterPosition, Vector3 shooterVelocity,
            float shotSpeed,
            Vector3 targetPosition,
            Vector3 targetVelocity)
    {
        Vector3 targetRelativePosition = targetPosition - shooterPosition;
        Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
        float t = FirstOrderInterceptTime
        (
            shotSpeed,
            targetRelativePosition,
            targetRelativeVelocity
        );
        return targetPosition + t * (targetRelativeVelocity);
    }

    public float FirstOrderInterceptTime
(
    float shotSpeed,
    Vector3 targetRelativePosition,
    Vector3 targetRelativeVelocity
)
    {
        float velocitySquared = targetRelativeVelocity.sqrMagnitude;

        if (velocitySquared < 0.001f)
            return 0f;

        float a = velocitySquared - shotSpeed * shotSpeed;
        Debug.Log(a);
        //handle similar velocities
        if (Mathf.Abs(a) < 0.001f)
        {
            float t = -targetRelativePosition.sqrMagnitude /
            (
                2f * Vector3.Dot
                (
                    targetRelativeVelocity,
                    targetRelativePosition
                )
            );
            return Mathf.Max(t, 0f); //don't shoot back in time
        }

        float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
        float c = targetRelativePosition.sqrMagnitude;
        float determinant = b * b - 4f * a * c;

        Debug.Log(a + " " + b + " " + c);
        Debug.Log("det "+determinant);
        if (determinant > 0f)
        { //determinant > 0; two intercept paths (most common)
            float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
                    t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
            Debug.Log(t1 + " " + t2);
            if (t1 > 0f)
            {
                if (t2 > 0f)
                    return Mathf.Min(t1, t2); //both are positive
                else
                    return t1; //only t1 is positive
            }
            else
                return Mathf.Max(t2, 0f); //don't shoot back in time
        }
        else if (determinant < 0f) //determinant < 0; no intercept path
            return 0f;
        else //determinant = 0; one intercept path, pretty much never happens
            return Mathf.Max(-b / (2f * a), 0f); //don't shoot back in time
    }

}
