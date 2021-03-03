using System;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private Transform _fixationPoint;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run()
    {
        _animator.SetBool("isRunning", true);
    }
    
    public void StopRun()
    {
        _animator.SetBool("isRunning", false);
    }

    public Transform FixationPoint => _fixationPoint;
}
