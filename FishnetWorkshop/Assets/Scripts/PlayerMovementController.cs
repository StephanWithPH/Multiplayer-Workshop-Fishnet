using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using FishNet.Object.Prediction;
using FishNet;
using FishNet.Transporting;


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

    private bool _jumpQueued;



    public struct MoveData : IReplicateData
    {
        public bool Jump;

        /* Everything below this is required for
        * the interface. You do not need to implement
        * Dispose, it is there if you want to clean up anything
        * that may allocate when this structure is discarded. */
        private uint _tick;
        public void Dispose() { }
        public uint GetTick() => _tick;
        public void SetTick(uint value) => _tick = value;
    }

    public struct ReconcileData : IReconcileData
    {
        public Vector3 Position;

        /* Everything below this is required for
        * the interface. You do not need to implement
        * Dispose, it is there if you want to clean up anything
        * that may allocate when this structure is discarded. */
        private uint _tick;
        public void Dispose() { }
        public uint GetTick() => _tick;
        public void SetTick(uint value) => _tick = value;
    }

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

        if (!base.IsOwner)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _jumpQueued = true;
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
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public bool IsGrounded()
    {
        RaycastHit hit;
        float rayLength = 1.1f; // Adjust based on your character's size
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            return true;
        }
        return false;
    }



    public override void OnStartNetwork()
    {
        base.OnStartNetwork();
        if (base.IsServer || base.IsClient)
            base.TimeManager.OnTick += TimeManager_OnTick;
    }

    public override void OnStopNetwork()
    {
        base.OnStopNetwork();
        if (base.TimeManager != null)
            base.TimeManager.OnTick -= TimeManager_OnTick;
    }

    private void TimeManager_OnTick()
    {
        if (base.IsOwner)
        {
            BuildActions(out MoveData md);
            Move(md, false);
        }
    }

    private void BuildActions(out MoveData moveData)
    {
        moveData = default;
        moveData.Jump = _jumpQueued;

        //Unset queued values.
        _jumpQueued = false;
    }

    [Replicate]
    private void Move(MoveData moveData, bool asServer, Channel channel = Channel.Unreliable, bool replaying = false)
    {
        //If jumping move the character up one unit.
        if (moveData.Jump && IsGrounded())
            rb.AddForce(transform.up * 10);
    }

    [Reconcile]
    private void Reconcile(ReconcileData recData, bool asServer, Channel channel = Channel.Unreliable)
    {
        //Reset the client to the received position. It's okay to do this
        //even if there is no de-synchronization.
        transform.position = recData.Position;
    }
}