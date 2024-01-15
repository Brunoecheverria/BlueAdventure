using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rangoDeAlerta;
    [SerializeField] private LayerMask capaDelJugador;
    [SerializeField] private Transform jugador;
    private bool estarAlerta;


    [SerializeField] private float daniXGolpe;
    [SerializeField] private float vidaJugador;
    [SerializeField] private float rateDanio;
    private float vidaActualJugador;
    private float timeRateDanio;





    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if(estarAlerta == true)
        {
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, speed * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && Time.time > timeRateDanio)
        {

            vidaActualJugador -= daniXGolpe;
            timeRateDanio = Time.time + rateDanio;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
    
    
}
