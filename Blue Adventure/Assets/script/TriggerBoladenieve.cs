using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerBoladenieve : MonoBehaviour
{
    [SerializeField] Transform spawnPoin;
    [SerializeField] GameObject bullet;
    [SerializeField] float shotForce = 1500f;
    [SerializeField] float shotRate;
    private float shotRateTime;


    IEnumerator disparar()
    {
        yield return new WaitForSeconds(0);
        shotRate = Random.Range(1, 4);
        if (Time.time > shotRateTime)
        {
            GameObject newBullet;
            newBullet = Instantiate(bullet, spawnPoin.position, spawnPoin.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoin.forward * shotForce);
            shotRateTime = Time.time + shotRate;
            Destroy(newBullet, 3);

            
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine("disparar");


        }
    }
}
