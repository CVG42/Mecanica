using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 vectores;
    [SerializeField] Vector3 velocidad;
    public int speed;

    void Start()
    {
        
    }

    void Update()
    {
        vectores = this.transform.position;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
