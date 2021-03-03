using System;
using PathCreation;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PathCreator _pathCreator;
    private float _distanceTravelled;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.MovePosition(_pathCreator.path.GetPointAtDistance(_distanceTravelled));
    }

    private void Update()
    {
        _distanceTravelled += Time.deltaTime * _speed;

        var nextPoint = _pathCreator.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
        nextPoint.y = transform.position.y;
        _rigidBody.MovePosition(nextPoint);
        transform.LookAt(nextPoint);
    }
}
