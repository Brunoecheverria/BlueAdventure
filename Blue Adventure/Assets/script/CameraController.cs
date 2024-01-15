using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    private float xRotation;
    private float mouseX;
    private float mouseY;


    Transform target;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        target = transform.parent;
        target.LookAt(transform.forward);




    }

    // Update is called once per frame
    void Update()
    {
        
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -5f, 20f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        target.Rotate(Vector3.up, mouseX);
       
        
        
    }
}
