using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    [SerializeField] GameObject Metas;
    void Update()
    {
        transform.forward = Metas.transform.forward;
    }
}
