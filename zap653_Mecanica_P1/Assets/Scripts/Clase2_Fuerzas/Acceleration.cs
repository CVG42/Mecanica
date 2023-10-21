using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    //public Vector3[] listaDeFuerzas;
    public float masa;
    public Vector3 velocidad;
    public Vector3 fuerzaResultante;
    public LineRenderer lineRenderer;
    public bool showTrails;

    private Acceleration[] physicsEngineArray;
    private const float bigG = 6.673e-11f;

    private List<Vector3> forcelist = new List<Vector3>();

    void Start()
    {
        lineRenderer.useWorldSpace = false;
        physicsEngineArray = GameObject.FindObjectsOfType<Acceleration>();
    }

    public void AddForce(Vector3 forceVector)
    {
        forcelist.Add(forceVector);
    }

    private void FixedUpdate()
    {
        CalculateGravity();
        fuerzaResultante = Vector3.zero;
        foreach (Vector3 forcevector in forcelist)
        {
            fuerzaResultante += forcevector;

        }
        forcelist = new List<Vector3>();

        /*
        for (int i = 0; i < listaDeFuerzas.Length; i++)
        {
            fuerzaResultante = fuerzaResultante + listaDeFuerzas[i];
        }*/

        lineRenderer.enabled = showTrails ? true : false;
        lineRenderer.SetPosition(0, -fuerzaResultante);

        Vector3 aceleracion = fuerzaResultante / masa;
        velocidad += aceleracion * Time.deltaTime;
        transform.position += velocidad * Time.deltaTime;
    }

    void CalculateGravity()
    {
        foreach (Acceleration physicsEngineA in physicsEngineArray)
        {
            foreach (Acceleration physicsEngineB in physicsEngineArray)
            {
                if (physicsEngineA != physicsEngineB && physicsEngineA != this)
                {
                    Vector3 offset = physicsEngineA.transform.position - physicsEngineB.transform.position;
                    float rSquared = Mathf.Pow(offset.magnitude, 2f);
                    float gravityMagnitude = bigG * physicsEngineA.masa * physicsEngineB.masa / rSquared;
                    Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

                    physicsEngineA.AddForce(-gravityFeltVector);
                }

            }
        }
    }
}
