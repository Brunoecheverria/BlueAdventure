using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _timeLife = 5f;
    //public GameObject _explosionEffects;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _timeLife);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            //Instantiate(_explosionEffects, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
