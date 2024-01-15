using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puente : MonoBehaviour
{
    
    private bool Dentro = false;
   
    public static bool tomada = false;
    public static bool tomada1 = false;
    public static bool tomada2 = false;
    public static bool tomada3 = false;
    public static bool tomada4 = false;
    public static bool tomada5 = false;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject PanelTecla;
    [SerializeField] GameObject puentesinmadera;
    [SerializeField] GameObject puentecompleto;
    [SerializeField] GameObject Maderas;

    //Musica
    GameObject musica;
    FMODUnity.StudioEventEmitter musicaEmitter;

    private void Start()
    {
        musica = GameObject.Find("Musica");
        musicaEmitter = musica.GetComponent<FMODUnity.StudioEventEmitter>();
    }



    void Update()
    {
        if (Dentro && Input.GetKeyDown(KeyCode.E) && tomada && tomada1 && tomada2 && tomada3 && tomada4 && tomada5)
        {


            puentesinmadera.SetActive(false);
            puentecompleto.SetActive(true);
            

        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Dentro = true;
            panel.SetActive(true);
            Maderas.SetActive(true);
            musicaEmitter.SetParameter("DosVoces", 1);
        }
        if (other.CompareTag("Player") && tomada && tomada1 && tomada2 && tomada3 && tomada4 && tomada5)
        {
            panel.SetActive(false);
            PanelTecla.SetActive(true);
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dentro = false;
            panel.SetActive(false);
        }
        if (other.CompareTag("Player") && tomada)
        {
            PanelTecla.SetActive(false);
        }

    }
}
