using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    public GameObject Bullet;

    [SerializeField] private float _timer = 2f;

    private int _counter;

    [SerializeField] int maxCounter = 20;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBullets_CR());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FireBullets_CR()
    {
        Debug.Log("Inicio corountine");
        for (int i = 0; i < maxCounter; i++)
        {
            _counter++;
            Instantiate(Bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(_timer);

        }
        Debug.Log("Fin corountine");
    }
}
