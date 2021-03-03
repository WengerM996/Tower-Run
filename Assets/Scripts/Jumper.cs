using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private bool isGrounded;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            isGrounded = false;
            _rigidBody.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Road road))
        {
            isGrounded = true;
        }
    }
}
