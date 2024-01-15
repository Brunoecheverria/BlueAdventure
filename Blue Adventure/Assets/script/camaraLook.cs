using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 80f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float minDistancia = 1;
    [SerializeField] private float maxDistancia = 5;
    private float mouseX;
    private float mouseY;
    private float xRotation;
    private float suavidad = 10;
    private float distancia;
    private Vector3 direccion;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        direccion = transform.localPosition.normalized;
        distancia = transform.localPosition.magnitude;

    }


    void Update()
    {
        Vector3 posDeCamera = transform.parent.TransformPoint(direccion * maxDistancia);
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, posDeCamera, out hit))
        {
            distancia = Mathf.Clamp(hit.distance * 0.85f, minDistancia, maxDistancia);
        }
        else
        {
            distancia = maxDistancia;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, direccion * distancia, suavidad * Time.deltaTime);
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
