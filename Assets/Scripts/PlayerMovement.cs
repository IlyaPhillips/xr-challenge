using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

// I'm using the Unity input system to make my controls easily extensible to other inputs like a gamepad

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Config")] 
    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxSpeed;

    [Header("References")] [SerializeField]
    private Camera mainCamera;
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
        //_cameraControls.started += CameraMovementStart;
        //_cameraControls.performed += CameraMovement;
        //_cameraControls.canceled += CameraMovementEnd;
        _cameraControls.Enable();
        // change to smooth camera controls using started and finished to start rotation and end
        
    }

    // private void CameraMovementEnd(InputAction.CallbackContext obj)
    // {
    //     _cameraMoving = false;
    // }
    //
    //
    //
    // private void CameraMovementStart(InputAction.CallbackContext obj)
    // {
    //     _cameraMoving = true;
    // }
    //
    // private void CameraMovement(InputAction.CallbackContext obj)
    // {
    //     var rotationAngle = obj.ReadValue<Vector2>().x;
    //     if (rotationAngle == 0) return;
    //     Debug.Log("Rotation Angle: " + rotationAngle);
    //     transform.Rotate(Vector3.up,rotationAngle);
    //     //mainCamera.transform.RotateAround(gameObject.transform.position, Vector3.up, rotationAngle * rotationSpeed);
    // }

    private void OnDisable()
    {
        _movement.Disable();
        _cameraControls.Disable();
    }

    private void FixedUpdate()
    {
        var movementVector = new Vector3(_movement.ReadValue<Vector2>().x, 0, _movement.ReadValue<Vector2>().y);
        transform.Rotate(Vector3.up,_cameraControls.ReadValue<Vector2>().x);

        _rb.AddRelativeForce(movementVector*speed);
        if (!(_rb.velocity.magnitude >= maxSpeed)) return;
        Debug.Log("Slow Down");
        var velocity = _rb.velocity;
        var brakingForce = velocity.magnitude;
        _rb.AddForce(-velocity.normalized*brakingForce);
    }
}
