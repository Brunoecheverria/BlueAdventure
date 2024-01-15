using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundsScript : MonoBehaviour
{
    [Header("Snapshot")]
    [SerializeField] FMODUnity.StudioEventEmitter eventSnapshot;
    [SerializeField] daniJugador danioJugador;
    [SerializeField] float blueHealth;
    
    private void Awake()
    {
        danioJugador.vidaActualJugador = danioJugador.vidaJugador;
    }

    private void Update()
    {
        blueHealth = danioJugador.vidaActualJugador;
        eventSnapshot.SetParameter("BlueHealth", blueHealth);


        if (blueHealth <= 20f)
        {
            FMODUnity.RuntimeManager.CreateInstance("event:/Fx/Health").start();
            eventSnapshot.SetParameter("BlueHealth", blueHealth);           
        }

        
        if (blueHealth >= 20f)
        {
            eventSnapshot.Play();
        }
    }
}
