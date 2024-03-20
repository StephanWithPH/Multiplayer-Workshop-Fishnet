using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : NetworkBehaviour
{
    public float moveSpeed = 7f;
    public float rotationSpeed = 100f;
    public float groundDrag = 5f;
    
    private Rigidbody rb;
    private Collider collider;
    private Vector2 moveInput;
    private bool isGrounded;
    private Vector3 movementDirection;
    private Vector3 movement;
    
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<Collider>();
        Debug.Log("Player is gespawned");
    }

    private void Update()
    {
        if (!IsOwner) return;
        var distanceToTheGround = collider.bounds.extents.y;
        isGrounded = Physics.Raycast(collider.bounds.center, Vector3.down, distanceToTheGround + 0.1f);

        LimitSpeed();
        
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;
        MovePlayer();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        print("move");
    }

    private void MovePlayer()
    {
        // change rotation
        var rotationToAdd = moveInput.x * rotationSpeed * Time.fixedDeltaTime;
        var finalRotation = Quaternion.Euler(Vector3.up * rotationToAdd);
        rb.MoveRotation(rb.rotation * finalRotation);
        
        // calculate movement direction
        movementDirection = transform.forward * moveInput.y;

        rb.AddForce(movementDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void LimitSpeed()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
