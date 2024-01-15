using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactusGigante : MonoBehaviour
{
    [SerializeField] float TimeRate;
    private float TimeRateAttack;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();    
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Time.time > TimeRateAttack)
        {
            ani.SetBool("attack", true);
            TimeRateAttack = Time.time + TimeRate;
        }
        else
        {
            ani.SetBool("attack", false);
        }
    }
}
