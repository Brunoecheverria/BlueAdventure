
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class daniJugador : MonoBehaviour
{
    [SerializeField] private float daniXGolpe;
    [SerializeField] private float daniXMisil;
    [SerializeField] private float danixPiso;
    [SerializeField] private float danixCaptus;
    [SerializeField] private float daniXZombie;
    [SerializeField] public float vidaJugador;
    [SerializeField] private float timerate;
    [SerializeField] private float timeratepiso;
    [SerializeField] private float timeCaptus;
    [SerializeField] private float timeSaludFogata;
    [SerializeField] private float timerateZombie;
    [SerializeField] private TextMeshProUGUI vida;
    public float vidaActualJugador;
    private float timeRateZombie;
    private float timeRateDanio;
    private float timeRateDaniopiso;
    private float timeRateSaludFogata;
    private float timeRateCaptus;
    private float r;
    private float g;
    private float b;
    private float a;
    [SerializeField] Image vidaImagen;
    [SerializeField] Image bloodEffect;
    [SerializeField] private float Daniobola;

    //Sonidos
    WaterPunchSounds wPSounds;

    

    void Start()
    {
        vidaActualJugador = vidaJugador;

        r = bloodEffect.color.r;
        g = bloodEffect.color.g;
        b = bloodEffect.color.b;
        a = bloodEffect.color.a;

        wPSounds = GameObject.Find("WaterPunchEvent").GetComponent<WaterPunchSounds>();

    }

    void Update()
    {
        a -= 0.00001f;
        changeColor();
        vida.text = vidaActualJugador.ToString();
        vidaImagen.fillAmount = vidaActualJugador / vidaJugador;
        if (vidaActualJugador <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bulletEnemy"))
        {

            vidaActualJugador -= daniXGolpe;
            Destroy(other.gameObject);
            timeRateDanio = Time.time + timerate;

        }

        if(other.gameObject.CompareTag("DanioBola"))
        {
            vidaActualJugador -= Daniobola;
            Destroy(other.gameObject);
           
        }
        if (other.gameObject.CompareTag("MisilPig"))
        {
            vidaActualJugador -= daniXMisil;
            Destroy(other.gameObject);
            
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("vida")&& vidaActualJugador < 100)
        {
            a -= 0.1f;
            vidaActualJugador += 20;
            wPSounds.WaterSound();
            Destroy(other.gameObject);
            if (vidaActualJugador > 100)
            {
                vidaActualJugador = 100;

                
            }
        }
        if (other.gameObject.CompareTag("Fogata") && vidaActualJugador < 100 && Time.time > timeRateSaludFogata)
        {
            a -= 0.1f;
            vidaActualJugador += 2f;
            timeRateSaludFogata = Time.time + timeSaludFogata;

            if (vidaActualJugador > 100)
            {
                vidaActualJugador = 100;
            }
        }
        if (other.gameObject.CompareTag("piso")&& Time.time > timeRateDaniopiso)
        {
            vidaActualJugador -= danixPiso;
            timeRateDaniopiso = Time.time + timeratepiso;
            
            a += 0.01f;
            
            a = Mathf.Clamp(a, 0, 1f);
        }
        if (other.gameObject.CompareTag("Cactus") && Time.time > timeRateCaptus)
        {
            
            vidaActualJugador -= danixCaptus;
            timeRateCaptus = Time.time + timeCaptus;
            
            a += 0.02f;
            a = Mathf.Clamp(a, 0, 1f);

            wPSounds.PunchSound();
        }
        if (other.gameObject.CompareTag("Zombie")&& Time.time > timeRateZombie)
        {
            vidaActualJugador -= daniXZombie;
            timeRateZombie = Time.time + timerateZombie;

        }


    }
    private void changeColor()
    {
        Color c = new Color(r, g, b, a);
        bloodEffect.color = c;
    }

  
}
