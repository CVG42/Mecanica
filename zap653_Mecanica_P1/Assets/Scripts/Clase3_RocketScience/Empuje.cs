using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Acceleration))]
public class Empuje : MonoBehaviour
{
	private Acceleration acceleration;

	[Range(0, 1f)]
	public float porcentaje;    
	
	public float masaCombustible;             
	private float propulsionActual;       
	public float propulsionMaxima;             
	public Vector3 vectorUnidadProp;

	void Start()
	{
		acceleration = GetComponent<Acceleration>();
		acceleration.masa += masaCombustible;
	}

	void FixedUpdate()
	{
		float flujoDeMasa;                          
		float velocidadDeEmpuje;                  

		velocidadDeEmpuje = 4462f;               
		flujoDeMasa = propulsionActual / velocidadDeEmpuje;
		flujoDeMasa *= Time.deltaTime;

		if (masaCombustible > flujoDeMasa)
		{
			masaCombustible -= flujoDeMasa;
			acceleration.masa -= flujoDeMasa;
			propulsionActual = propulsionMaxima * porcentaje * 1000f;
			Vector3 empuje = vectorUnidadProp.normalized * propulsionActual;
			acceleration.AddForce(empuje);

		}
	}
}
