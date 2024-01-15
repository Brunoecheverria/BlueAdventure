using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaPuente4 : MonoBehaviour
{
    private bool dentro = false;
    [SerializeField] GameObject tabla;
       

          
  
    [SerializeField] GameObject Dialogo;
    void Update()
    {
   
        if (dentro && Input.GetKeyDown(KeyCode.E))
        {
            Puente.tomada4 = true;
            tabla.SetActive(false);

        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentro = true;
            Dialogo.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentro = false;
            Dialogo.SetActive(false);

        }
    }
}
