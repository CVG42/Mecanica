using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    public Vector3[] forces;
    public Vector3 acceleration;
    public Vector3 velocity;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        for(int i=0; i<forces.Length; i++)
        {
            acceleration += forces[i];
        }

        velocity += acceleration;
        transform.position += velocity * Time.deltaTime;
    }
}
