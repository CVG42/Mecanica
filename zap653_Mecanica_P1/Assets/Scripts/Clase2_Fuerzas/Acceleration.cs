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

    void Start()
    {
        lineRenderer.useWorldSpace = false;
    }

    private void FixedUpdate()
    {
        fuerzaResultante = Vector3.zero;

        for (int i = 0; i < listaDeFuerzas.Length; i++)
        {
            fuerzaResultante = fuerzaResultante += listaDeFuerzas[i];
        }

        lineRenderer.enabled = showTrails ? true : false;
        lineRenderer.SetPosition(0,-fuerzaResultante);

        Vector3 aceleracion = fuerzaResultante / masa;
        velocidad += aceleracion * Time.deltaTime;
        transform.position += velocidad * Time.deltaTime;
    }
}
