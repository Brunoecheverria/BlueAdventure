using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PajaroAmigo : MonoBehaviour
{
    [SerializeField] GameObject TextAmigo;
    [SerializeField] GameObject pared;

    private void OnTriggerEnter(Collider other)    
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextAmigo.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Entrar()
    {
        pared.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(TextAmigo);
    }
    public void Corre()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

    
}
