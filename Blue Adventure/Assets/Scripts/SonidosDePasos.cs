using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosDePasos : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioEventEmitter pasosEmitter, saltoEmitter;

    public void Pasos()
    {
        pasosEmitter.Play();
    }

    public void Salto()
    {
        saltoEmitter.Play();
    }
}
