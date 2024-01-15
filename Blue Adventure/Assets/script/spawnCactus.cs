using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCactus : MonoBehaviour
{
    [SerializeField] GameObject Captus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Captus.gameObject.SetActive(true);
        }
    }
}
