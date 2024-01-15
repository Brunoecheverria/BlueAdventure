using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Zombies : MonoBehaviour
{

    [SerializeField] private float rangoDeAlerta;
    [SerializeField] private float speed;
    [SerializeField] private float daniXGolpe;
    [SerializeField] private float vidaEnemy;
    [SerializeField] private Image imagenBarraVida;
    [SerializeField] Transform jugador;
    [SerializeField] LayerMask capaDelJugador;
    [SerializeField] private TextMeshProUGUI vidaText;
    Animator ani;
    

    private float vidaActualEnemy;
    private bool estarAlerta;


    private void Start()
    {
        ani = GetComponent<Animator>();
        vidaActualEnemy = vidaEnemy;
  
      

    }


    void Update()
    {
      
        RevisarVida();
      
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta == true)
        {
            ani.SetFloat("moveEnemy", 0.5f, 0.1f, Time.deltaTime);
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, speed * Time.deltaTime);

        }
        if (estarAlerta == false) 
        {
            ani.SetFloat("moveEnemy", 0.0f, 0.01f, Time.deltaTime);
        }


        if (vidaActualEnemy <= 0)
        {
            
            ani.SetTrigger("muere");
            Destroy(gameObject, 2.5f);
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
    public void RevisarVida()
    {
        vidaText.text = vidaActualEnemy.ToString();
        imagenBarraVida.fillAmount = vidaActualEnemy / vidaEnemy;
    }
    private void OnTriggerStay(Collider other)
    {
        ani.SetFloat("moveEnemy", 1.0f, 0.01f, Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            vidaActualEnemy -= daniXGolpe;

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
        }
    }
}
