using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using FishNet.Object.Prediction;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : NetworkBehaviour
{
    public float moveSpeed = 35f;
    public float rotationSpeed = 100f;
    
    public Rigidbody rb;
    public Vector3 movementInput;
    
    private Vector3 movementVectorToAdd;
    private Quaternion rotation;
    
    private void Start()
    {
        Debug.Log("Player is gespawned");
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var rotationToAdd = movementInput.x * rotationSpeed * Time.deltaTime;
        var finalRotation = Quaternion.Euler(Vector3.up * rotationToAdd);
        rotation = finalRotation * rb.rotation;

        var movementDirection = transform.forward * movementInput.y;
        movementVectorToAdd = movementDirection.normalized * moveSpeed * 10f;

        if (movementVectorToAdd != Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }

        rb.MoveRotation(rotation);
        rb.AddForce(movementVectorToAdd, ForceMode.Force);
    }
}