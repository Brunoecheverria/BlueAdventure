using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class movimientochanchito : MonoBehaviour
{

    [SerializeField] float amplitudX;  // Controla la amplitud del movimiento
    [SerializeField] float velocidadX;

    [SerializeField] private float daniXGolpe;
    [SerializeField] private float vidaEnemy;
    [SerializeField] private TextMeshProUGUI vida;
    [SerializeField] Image vidaImagen;
    private float vidaActualJugador;
    




    // Posición inicial en x
    float posicionInicialX;

    void Start()
    {
        vidaActualJugador = vidaEnemy;
        // Guarda la posición inicial en x
        posicionInicialX = transform.position.x;
    }

    void Update()
    {
        vida.text = vidaActualJugador.ToString();
        vidaImagen.fillAmount = vidaActualJugador / vidaEnemy;
        if (vidaActualJugador <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Cursor.lockState = CursorLockMode.None;
        }
    
      // Calcula la posición horizontal usando un movimiento oscilante entre -1 y 1
      float pingPongValue = Mathf.PingPong(Time.time * velocidadX, 2.0f) - 1.0f;

        // Multiplica el valor por la amplitud para controlar la amplitud del movimiento
        float movimientoX = pingPongValue * amplitudX;

        // Suma la posición inicial en x
        movimientoX += posicionInicialX;

        // Actualiza la posición del objeto
        transform.position = new Vector3(movimientoX, transform.position.y, transform.position.z);

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            vidaActualJugador -= daniXGolpe;
            
        }
    }
}
