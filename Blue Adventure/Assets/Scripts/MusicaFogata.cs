using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaFogata : MonoBehaviour
{
    FMOD.Studio.EventInstance fogataCampanas, fogataCampanas2, fogataCampanas3;
    [SerializeField] GameObject fogata1, fogata2, fogata3;

    private void Start()
    {
        fogataCampanas = FMODUnity.RuntimeManager.CreateInstance("event:/Campanas3D");
        fogataCampanas.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(fogata1));
        fogataCampanas.start();
    }
}
