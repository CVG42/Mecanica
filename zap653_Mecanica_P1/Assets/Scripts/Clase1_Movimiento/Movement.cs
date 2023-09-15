using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 velocidad;

    private void FixedUpdate()
    {
        transform.position += velocidad * Time.deltaTime;
    }
}



