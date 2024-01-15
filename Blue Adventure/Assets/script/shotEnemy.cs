using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotEnemy : MonoBehaviour
{
    [SerializeField] Transform spawnPoin;
    [SerializeField] GameObject bullet;
    [SerializeField] float shotForce = 1500f;
    [SerializeField] float shotRate = 0.5f;
    private float shotRateTime = 0f;


   
    



    void Update()
    {
      
        


            StartCoroutine("disparar");

        

    }
    IEnumerator disparar()
    {
        yield return new WaitForSeconds(1);
        if (Time.time > shotRateTime)
        {

            GameObject newBullet;
            newBullet = Instantiate(bullet, spawnPoin.position, spawnPoin.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoin.right * shotForce);
            shotRateTime = Time.time + shotRate;
            Destroy(newBullet, 1);

        }
    }
}
