using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shootCatapulta : MonoBehaviour
{
    [SerializeField] Transform spawnPoin;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject camara;
    [SerializeField] float shotForce = 1500f;
    [SerializeField] float shotRate = 0.5f;
    private float shotRateTime = 0f;
    private Animator ani;

    //Sonido
    FMODUnity.StudioEventEmitter lanzamientoEmitter;

    private void Start()
    {
        ani = GetComponent<Animator>();
        lanzamientoEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }



    
    
    IEnumerator disparar()
    {
        yield return new WaitForSeconds(0);
        if (Time.time > shotRateTime)
        {
            lanzamientoEmitter.Play();
            camara.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
            ani.SetBool("DPlayer", true);
            Invoke("cambioEscena", 2);
            GameObject newBullet;
            newBullet = Instantiate(bullet , spawnPoin.position, bullet.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoin.forward * shotForce);
            shotRateTime = Time.time + shotRate;
            Destroy(newBullet, 1);
            
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          StartCoroutine("disparar");

        }
    }
     void cambioEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}

