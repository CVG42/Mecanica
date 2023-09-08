using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour
{

	public float fuelMass;              
	public float maxThrust;            

	[Range(0, 1f)]
	public float thrustPercent;         

	public Vector3 thrustUnitVector;   

	private PhysicsEngine physicsEngine;
	private float currentThrust;       

	void Start()
	{
		physicsEngine = GetComponent<PhysicsEngine>();
		physicsEngine.mass += fuelMass;
	}

	void FixedUpdate()
	{
		if (fuelMass > FuelThisUpdate())
		{
			fuelMass -= FuelThisUpdate();
			physicsEngine.mass -= FuelThisUpdate();
			ExertForce();
		}
		else
		{
			Debug.LogWarning("Out of rocket fuel");
		}
	}

	float FuelThisUpdate()
	{                      
		float exhaustMassFlow;                          
		float effectiveExhastVelocity;                  

		effectiveExhastVelocity = 4462f;               
		exhaustMassFlow = currentThrust / effectiveExhastVelocity;

		return exhaustMassFlow * Time.deltaTime;
	}

	void ExertForce()
	{
		currentThrust = thrustPercent * maxThrust * 1000f;
		Vector3 thrustVector = thrustUnitVector.normalized * currentThrust; 
		physicsEngine.AddForce(thrustVector);
	}
}