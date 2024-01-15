using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cañon;  // Asigna el GameObject del cañón en el Inspector
    public Camera mainCamera;  // Asigna la cámara principal en el Inspector
    public Camera cannonCamera;  // Asigna la cámara del cañón en el Inspector
    public GameObject personaje; // Asigna el GameObject del personaje en el Inspector
    public float launchForce = 10f;  // Fuerza con la que se lanzará al personaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ajusta la etiqueta del jugador según tus necesidades
        {
            Fire(other.gameObject);
        }
    }

    void Fire(GameObject character)
    {
        // Cambia la cámara a la del cañón
        mainCamera.enabled = false;
        cannonCamera.enabled = true;

        // Obtén la dirección hacia adelante del cañón (en la dirección positiva del eje Z)
        Vector3 launchDirection = cañon.transform.forward;

        // Aplica la fuerza al personaje existente
        character.GetComponent<Rigidbody>().AddForce(launchDirection * launchForce, ForceMode.Impulse);
    }
}
