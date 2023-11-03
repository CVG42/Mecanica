using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public Magnus ball;

	private float extraSpeedPerFrame;

	// Use this for initialization
	void Start()
	{
		extraSpeedPerFrame = (ball.maxCoefficient * Time.fixedDeltaTime);
	}

	void OnMouseDown()
	{
		// Increase ball speed to max over a few seconds
		// Consdider InvokeRepeating
		ball.magnusCoefficient = 0;
		InvokeRepeating("IncreaseLaunchSpeed", 0.5f, Time.fixedDeltaTime);
	}

	void OnMouseUp()
	{
		CancelInvoke();
		Magnus newBall = Instantiate(ball) as Magnus;
		newBall.transform.parent = GameObject.Find("Launched Balls").transform;
		//Vector3 launchVelocity = new Vector3(1, 1, 0).normalized * ball.magnusCoefficient;
		//newBall.velocityVector = launchVelocity;
		Rigidbody rb = newBall.GetComponent<Rigidbody>();
		if(rb != null)
        {
			rb.AddForce(ball.GetComponent<Magnus>().CalculateMagnusForce() * Time.fixedDeltaTime);
		}
	}

	void IncreaseLaunchSpeed()
	{
		if (ball.magnusCoefficient <= ball.maxCoefficient)
		{
			ball.magnusCoefficient += extraSpeedPerFrame;
		}
	}
}
