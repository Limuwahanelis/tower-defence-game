using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedx = 30f;
    public float speedy = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxisRaw("Mouse ScrollWheel") * Time.deltaTime * speedx);
        transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * speedy);


    }
}
