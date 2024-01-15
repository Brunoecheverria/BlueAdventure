using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAlDisparar : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioEventEmitter emitter;
    public void SonidoDisparo()
    {
        emitter.Play();
    }
}
