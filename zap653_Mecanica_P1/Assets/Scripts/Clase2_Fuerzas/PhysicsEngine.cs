using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsEngine : MonoBehaviour
{
	public float mass;           
	public Vector3 velocityVector;
	public Vector3 netForceVector; 

	private List<Vector3> forceVectorList = new List<Vector3>();
	private PhysicsEngine[] physicsEngineArray;
	private const float bigG = 6.673e-11f;

	void Start()
	{
		SetupThrustTrails();
		physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
	}



	private void FixedUpdate()
	{
		RenderTrails();
		CalculateGravity();
		UpdatePosition();
	}

	public void AddForce(Vector3 forceVector)
	{
		forceVectorList.Add(forceVector);
		Debug.Log("Adding force " + forceVector + " to " + gameObject.name);
	}

	void CalculateGravity()
	{
		foreach (PhysicsEngine physicsEngineA in physicsEngineArray)
		{
			foreach (PhysicsEngine physicsEngineB in physicsEngineArray)
			{
				if (physicsEngineA != physicsEngineB)
				{
					Debug.Log("Calculating force exerted on " + physicsEngineA.name +
								" due to the gravity of " + physicsEngineB.name);
					if (physicsEngineA != physicsEngineB && physicsEngineA != this)
					{
						Vector3 offset = physicsEngineA.transform.position - physicsEngineB.transform.position;
						float rSquared = Mathf.Pow(offset.magnitude, 2f);
						float gravityMagnitude = bigG * physicsEngineA.mass * physicsEngineB.mass / rSquared;
						Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

						physicsEngineA.AddForce(-gravityFeltVector);
					}
				}
			}
		}
	}

		void UpdatePosition()
		{
			netForceVector = Vector3.zero;
			foreach (Vector3 forceVector in forceVectorList)
			{
				netForceVector = netForceVector + forceVector;
			}
			forceVectorList = new List<Vector3>();

			Vector3 accelerationVector = netForceVector / mass;
			velocityVector += accelerationVector * Time.deltaTime;
			transform.position += velocityVector * Time.deltaTime;
		}
	

	public bool showTrails = true;

	private LineRenderer lineRenderer;
	private int numberOfForces;

	void SetupThrustTrails()
	{
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		//lineRenderer.SetColors(Color.yellow, Color.yellow);
		//lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.useWorldSpace = false;
	}
	void RenderTrails()
	{
		if (showTrails)
		{
			lineRenderer.enabled = true;
			numberOfForces = forceVectorList.Count;
			lineRenderer.positionCount = numberOfForces * 2;
			int i = 0;
			foreach (Vector3 forceVector in forceVectorList)
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