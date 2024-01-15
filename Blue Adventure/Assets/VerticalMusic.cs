using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class VerticalMusic : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioEventEmitter musicEmitter;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("col");
            musicEmitter.SetParameter("VerticalMusic", 1f);
            this.gameObject.SetActive(false);
        }
    }
}
