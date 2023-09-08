using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    public Vector3[] listaDeFuerzas;
    public float masa;
    public Vector3 velocidad;
    public Vector3 fuerzaResultante;
    public LineRenderer lineRenderer;
    public bool showTrails;
    private int numberOfForces;

    void Start()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.startColor = Color.yellow; lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 0.2F; lineRenderer.endWidth = 0.2F;
    }
    void Update()
    {
    }

    private void FixedUpdate()
    {
        RenderTrails();
        fuerzaResultante = Vector3.zero;

        for (int i = 0; i < listaDeFuerzas.Length; i++)
        {
            fuerzaResultante = fuerzaResultante += listaDeFuerzas[i];
        }


        Vector3 aceleracion = fuerzaResultante / masa;
        velocidad += aceleracion * Time.deltaTime;
        transform.position += velocidad * Time.deltaTime;
    }
    
    void RenderTrails()
    {
        if (showTrails)
        {
            lineRenderer.enabled = true;
            numberOfForces = listaDeFuerzas.Length;
            lineRenderer.positionCount = numberOfForces * 2;
            int i = 0;

            foreach (Vector3 forceVector in listaDeFuerzas)
            {
                lineRenderer.SetPosition(i, Vector3.zero);
                lineRenderer.SetPosition(i + 1, -forceVector);
                i = i + 2;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
