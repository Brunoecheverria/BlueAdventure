using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparaFireBalls : MonoBehaviour

   {

    public Transform shootingPoint;
    public GameObject fireBall;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireBall, shootingPoint.transform.position, Quaternion.identity);
        }
        
    }
}
