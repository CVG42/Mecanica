using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform esfera;
    public Vector3 offset = new Vector3(0, 2, - 10);
    public bool canFollow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(canFollow)
            transform.position = esfera.position + offset;
    }
}
