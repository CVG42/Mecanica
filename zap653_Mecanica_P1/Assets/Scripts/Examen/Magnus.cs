using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnus : MonoBehaviour
{
    public float magnusCoefficient = 0f;
    public float maxCoefficient = 8;
    public Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        _rigidbody.AddForce(CalculateMagnusForce() * mouse.direction.magnitude * Time.fixedDeltaTime);
    }

    public Vector3 CalculateMagnusForce()
    {
        return magnusCoefficient * Vector3.Cross(_rigidbody.angularVelocity, _rigidbody.velocity);
    }
}
