using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPig : MonoBehaviour
{
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.forward =  player.transform.forward;

    }
}
