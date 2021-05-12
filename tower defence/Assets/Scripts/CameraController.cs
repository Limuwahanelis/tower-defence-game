using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    float screenX = Screen.width;
    float screenY = Screen.height;
 


    public Vector3 offset;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    [SerializeField]
    private float yaw = 0.0f;
    [SerializeField]
    private float pitch = 0.0f;


    //public GameObject focalPoint;

    bool locked = true;

    public Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - focalPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        if (mouseX < 0 || mouseX > screenX || mouseY < 0 || mouseY > screenY)
            return;
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * (-Input.GetAxis("Mouse Y"));
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (locked)
            {
                Unlock();
            }
            else
            {
                LockInWindow();
            }
        }
        //if (pitch >= 45f)
        //    pitch = 45f;
        //if (pitch <= -2.5f)
        //    pitch = -2.5f;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        rotation = Quaternion.Euler(pitch, yaw, 0);
        //transform.position = focalPoint.transform.position - (rotation * (-offset));


    }

    void LockInWindow()
    {
        Cursor.lockState = CursorLockMode.Confined;
        locked = !locked;
    }
    void Unlock()
    {
        Cursor.lockState = CursorLockMode.None;
        locked = !locked;
    }
    public float GetYaw()
    {
        return yaw;
    }
}
