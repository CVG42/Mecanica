using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Acceleration))]
public class Empuje : MonoBehaviour
{
	public float masaCombustible;             
	private float empujeActual;       
	public float empujeMaximo;             
	public Vector3 empujeVector;    

	[Range(0, 1f)]
	public float porcentaje;         

	private Acceleration acceleration;

	void Start()
	{
		acceleration = GetComponent<Acceleration>();
		acceleration.masa += masaCombustible;
	}

	void FixedUpdate()
	{
		if (masaCombustible > Combustible())
		{
			masaCombustible -= Combustible();
			acceleration.masa -= Combustible();
			//ExertForce();
		}
	}

	float Combustible()
	{                           
		float flujoDeMasa;                          
		float velocidadDeEmpuje;                  

		velocidadDeEmpuje = 4462f;               
		flujoDeMasa = empujeActual / velocidadDeEmpuje;

		return flujoDeMasa * Time.deltaTime;
	}
	/*
	void ExertForce()
	{
		empujeActual = porcentaje * empujeMaximo * 1000f;
		Vector3 thrustVector = empujeVector.normalized * empujeActual;
	}*/
}
