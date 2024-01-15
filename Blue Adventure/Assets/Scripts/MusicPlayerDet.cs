using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayerDet : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] FMODUnity.StudioEventEmitter music;
    [SerializeField] float musicOrder = 0;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            music.SetParameter("VerticalMusic", musicOrder);
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
