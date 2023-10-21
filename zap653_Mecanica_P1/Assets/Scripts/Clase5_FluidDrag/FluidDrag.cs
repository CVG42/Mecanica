using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour
{
    private Acceleration acceleration;

    [Range(1, 2f)] 
    public float exponente;
   
    public float coeficiente;

    void Start()
    {
        acceleration = GetComponent<Acceleration>();
    }

    void FixedUpdate()
    {
        float arrastre = coeficiente * Mathf.Pow(acceleration.velocidad.magnitude, exponente);
        Vector3 vectorArrastre = arrastre * -acceleration.velocidad.normalized;
        acceleration.AddForce(vectorArrastre);
    }
}
