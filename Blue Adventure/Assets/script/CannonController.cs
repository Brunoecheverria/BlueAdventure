using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ca�on;  // Asigna el GameObject del ca��n en el Inspector
    public Camera mainCamera;  // Asigna la c�mara principal en el Inspector
    public Camera cannonCamera;  // Asigna la c�mara del ca��n en el Inspector
    public GameObject personaje; // Asigna el GameObject del personaje en el Inspector
    public float launchForce = 10f;  // Fuerza con la que se lanzar� al personaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ajusta la etiqueta del jugador seg�n tus necesidades
        {
            Fire(other.gameObject);
        }
    }

    void Fire(GameObject character)
    {
        // Cambia la c�mara a la del ca��n
        mainCamera.enabled = false;
        cannonCamera.enabled = true;

        // Obt�n la direcci�n hacia adelante del ca��n (en la direcci�n positiva del eje Z)
        Vector3 launchDirection = ca�on.transform.forward;

        // Aplica la fuerza al personaje existente
        character.GetComponent<Rigidbody>().AddForce(launchDirection * launchForce, ForceMode.Impulse);
    }
}
