using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirJefe : MonoBehaviour
{
    bool dentro;
    [SerializeField] GameObject elixir;
    [SerializeField] GameObject Texto;
    [SerializeField] GameObject arma;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dentro == true)
        {
            Texto.SetActive(false);
            elixir.SetActive(false);
            arma.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        dentro = true;
        
        Texto.SetActive(true);

    }
    private void OnTriggerExit(Collider other)
    {
        dentro = false;
        Texto.SetActive(false);
    }
}
