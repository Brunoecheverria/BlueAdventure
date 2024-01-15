using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VertMusicCol1 : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioEventEmitter musicEmissor;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("col");
            musicEmissor.SetParameter("VerticalMusic", +1f);
            this.gameObject.SetActive(false);
        }
    }
}
