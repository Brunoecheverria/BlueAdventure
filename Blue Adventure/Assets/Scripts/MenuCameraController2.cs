using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController2 : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] float xSens;
    [SerializeField] float ySens;
    [SerializeField] float xMax;
    [SerializeField] float xMin;
    [SerializeField] float yMax;
    [SerializeField] float yMin;
    [SerializeField] Vector3 offset;

    float mouseX;
    float mouseY;

    Vector3 limX;
    Vector3 limY;

    private void Start()
    {
        limX.x -= offset.y;
        limY.y += offset.x;


    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        cam.transform.localEulerAngles = limX;
        limX.x -= mouseY;

        if (limX.x >= yMax)
        {
            limX.x = yMax;
        }
        else if (limX.x <= yMin)
        {
            limX.x = yMin;
        }
        
        transform.localEulerAngles = limY;
        limY.y += mouseX;

        if (limY.y >= xMax)
        {
            limY.y = xMax;
        }
        else if (limY.y <= xMin)
        {
            limY.y = xMin;
        }
    }
}
