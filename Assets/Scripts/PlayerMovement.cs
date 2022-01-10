using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Config")] 
    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxSpeed;

    [Header("References")] [SerializeField]
    private Controls _controls;
    private InputAction _movement;
    private InputAction _cameraControls;
    private Rigidbody _rb;
    

    private void Awake()
    {
        _controls = new Controls();
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _movement = _controls.Player.Movement;
        _movement.Enable();
        _cameraControls = _controls.Player.Camera;
        _cameraControls.Enable();
    }

    

    private void OnDisable()
    {
        _movement.Disable();
        _cameraControls.Disable();
    }

    private void FixedUpdate()
    {
        var movementVector = new Vector3(_movement.ReadValue<Vector2>().x, 0, _movement.ReadValue<Vector2>().y);
        transform.Rotate(Vector3.up,_cameraControls.ReadValue<Vector2>().x*rotationSpeed);
        _rb.AddRelativeForce(movementVector*speed);
        if (!(_rb.velocity.magnitude >= maxSpeed)) return; //brakes the player when they're going above the max speed
        var velocity = _rb.velocity;
        var brakingForce = velocity.magnitude;
        _rb.AddForce(-velocity.normalized*brakingForce);
    }
}
