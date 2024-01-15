using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootPig : MonoBehaviour
{
    [SerializeField] Transform spawnPoin;
    [SerializeField] GameObject bullet;
    [SerializeField] float shotForce = 1500f;
    [SerializeField] float shotRate = 0.5f;
    private float shotRateTime = 0f;

    private void Start()
    {

    }



    void Update()
    {
       

    }
   
   
    IEnumerator disparar()
    {
        yield return new WaitForSeconds(0);
        if (Time.time > shotRateTime)
        {


            GameObject newBullet;
            newBullet = Instantiate(bullet, spawnPoin.position, spawnPoin.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoin.forward * shotForce);
            shotRateTime = Time.time + shotRate;
            Destroy(newBullet, 1);

        }
    }
    private void OnTriggerStay(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
            StartCoroutine("disparar");
       }
    }
}
