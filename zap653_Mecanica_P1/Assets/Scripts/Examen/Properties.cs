using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private Vector3 angularVelocity = Vector3.zero;

    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.velocity = velocity;
        _rigidbody.angularVelocity = angularVelocity;
    }
}
