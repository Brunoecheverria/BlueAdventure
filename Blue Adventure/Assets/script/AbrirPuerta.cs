using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    Animator animator;
    private bool Dentro = false;
    private bool Puerta = false;
    [SerializeField] GameObject panel;

    //Sonido
    GameObject chillido;
    FMODUnity.StudioEventEmitter chillidoEmitter;
    GameObject music;
    FMODUnity.StudioEventEmitter musicEmitter;

    void Start()
    {
        
        animator = GetComponent<Animator>();
        chillido = GameObject.Find("ChillidoCerdoSonido");
        chillidoEmitter = chillido.GetComponent<FMODUnity.StudioEventEmitter>();
        music = GameObject.Find("Music");
        musicEmitter = music.GetComponent<FMODUnity.StudioEventEmitter>();
    }


    void Update()
    {
        if (Dentro && Input.GetKeyDown(KeyCode.E))
        {
            Puerta = !Puerta;
            chillidoEmitter.Play();
            musicEmitter.SetParameter("PostPuerta", 1f);

        }
        if (Puerta)
        {
            animator.SetBool("AbrirPuerta", true);

        }
        else
        {
            animator.SetBool("AbrirPuerta", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dentro = true;
            panel.SetActive(true);
        }
      

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dentro = false;
            panel.SetActive(false);
        }
       
    }

}
