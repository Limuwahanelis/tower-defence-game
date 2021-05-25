using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public int attackDamage;
    public bool isOnAutoPilot = false;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //transform.forward = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnAutoPilot)
        {
            transform.LookAt(target.transform);
        }
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dd");
        if (other.GetComponent<IDamagable>()!=null)
        {
            
            other.GetComponent<IDamagable>().TakeDamage(attackDamage);
        }
    }
}
