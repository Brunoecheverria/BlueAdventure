using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    [SerializeField] GameObject canvasPausa;
    //bool _juegoPausado = false;
    
    public void Salir()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NuevoIntento()
    {
        SceneManager.LoadScene("Laberinto");
    }

    public void Reanudar()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("CanvasPausa").SetActive(false);
        //_juegoPausado = false;
    }
}
