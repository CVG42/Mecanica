using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    private Transform tr;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }


    void Update()
    {
        if (transform.eulerAngles.y == 90)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if(transform.eulerAngles.y == -90)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
