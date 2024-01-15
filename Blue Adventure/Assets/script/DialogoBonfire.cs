using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoBonfire : MonoBehaviour
{
    private bool Dentro = false;
    [SerializeField] GameObject Fogata;
    [SerializeField] GameObject Dialogo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dentro = true;
            Dialogo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dentro = false;
            Dialogo.SetActive(false);
        }
    }
}
