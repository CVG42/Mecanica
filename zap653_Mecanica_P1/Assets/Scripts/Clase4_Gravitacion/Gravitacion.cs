using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitacion : MonoBehaviour
{
    private Acceleration[] acceleration;
    private const float g = 6.673e-11f;
    void Start()
    {
        acceleration = GameObject.FindObjectsOfType<Acceleration>();
    }

    private void FixedUpdate()
    {
        foreach(Acceleration obj1 in acceleration)
        {
            foreach(Acceleration obj2 in acceleration)
            {
                if(obj1 != obj2 && obj1 != this)
                {
                    Vector3 deltaR = obj1.transform.position - obj2.transform.position;
                    float distanciaR = Mathf.Pow(deltaR.magnitude, 2);
                    float gravitacion = g * obj1.masa * obj2.masa / distanciaR;
                    Vector3 atraccion = gravitacion * deltaR.normalized;
                    obj1.AddForce(-atraccion);
                }
            }
        }
    }
}
