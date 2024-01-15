using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPingui : MonoBehaviour
{
    [SerializeField] GameObject pingui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pingui.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pingui.gameObject.SetActive(false);
        }
    }
}
