using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public Magnus ball;

	private float extraSpeedPerFrame;

	public Transform ballPos;
	public Transform startP;
	public Transform endP;
	public float speed;

	int direction = 1;
	void Start()
	{
		extraSpeedPerFrame = (ball.maxCoefficient * Time.fixedDeltaTime);
	}


	void Update()
	{
		Vector3 target = movement();
		ballPos.position = Vector3.Lerp(ballPos.position, target, speed * Time.deltaTime);
		float distance = (target - (Vector3)ballPos.position).magnitude;
		if (distance <=.1f)
        {
			direction *= -1;
        }

	}

	Vector3 movement()
    {
		if(direction == 1)
		{ 
			return startP.position;
		}
        else
        {
			return endP.position;
        }
    }

	void OnMouseDown()
	{
		ball.magnusCoefficient = 0;
		InvokeRepeating("IncreaseLaunchSpeed", 0.5f, Time.fixedDeltaTime);
	}

	void OnMouseUp()
	{
		CancelInvoke();
		Magnus newBall = Instantiate(ball, transform.position, Quaternion.identity) as Magnus;
		newBall.transform.parent = GameObject.Find("Launched Balls").transform;
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
