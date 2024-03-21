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
    
    private Rigidbody rb;
    public Vector3 movementInput;
    
    private Vector3 movementVectorToAdd;
    private Quaternion rotation;
    
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log("Player is gespawned");
    }

    public void OnMove(InputValue value)
    {
        if (!IsOwner) return;
        movementInput = value.Get<Vector2>();
    }

    [Replicate]
    private void MovePlayer(MoveData moveData, bool asServer, Channel channel = Channel.Unreliable, bool replaying = false)
    {
        Debug.Log($"Player movement");
        var rotationToAdd = moveData.Input.x * rotationSpeed * (float)TimeManager.TickDelta;
        var finalRotation = Quaternion.Euler(Vector3.up * rotationToAdd);
        rotation = finalRotation * rb.rotation;
        
        var movementDirection = transform.forward * moveData.Input.y;
        movementVectorToAdd = movementDirection.normalized * moveSpeed * 10f;

        if (movementVectorToAdd != Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
        
        rb.MoveRotation(rotation);
        rb.AddForce(movementVectorToAdd, ForceMode.Force);
    }
    
    [Reconcile]
    private void Reconcile(ReconcileData recData, bool asServer, Channel channel = Channel.Unreliable)
    {
        //Reset the client to the received position. It's okay to do this
        //even if there is no de-synchronization.
        Debug.Log($"Reconciling positions");
        rb.velocity = recData.Velocity;
        rb.rotation = recData.Rotation;
        transform.position = recData.Position;
    }

    public override void OnStartNetwork()
    {
        base.OnStartNetwork();
        base.TimeManager.OnTick += TimeManager_OnTick;
        base.TimeManager.OnPostTick += TimeManager_OnPostTick;
    }

    public override void OnStopNetwork()
    {
        base.OnStopNetwork();
        if (base.TimeManager != null)
            base.TimeManager.OnTick -= TimeManager_OnTick;

        if (base.TimeManager != null)
            base.TimeManager.OnPostTick -= TimeManager_OnPostTick;
    }

    private void TimeManager_OnTick()
    {
        if (base.IsOwner)
        {
            Reconcile(default, false);
            BuildActions(out MoveData md);
            MovePlayer(md, false);
        }

        if (base.IsServer)
        {
            MovePlayer(default, true);
        }
    }

    private void TimeManager_OnPostTick()
    {
        if (base.IsServer)
        {
            ReconcileData rd = new ReconcileData()
            {
                Velocity = rb.velocity,
                Rotation = rb.rotation,
                Position = transform.position
            };
            Reconcile(rd, true);
        }
    }

    private void BuildActions(out MoveData moveData)
    {
        moveData = default;
        moveData.Input = movementInput;
    }
}

public struct MoveData : IReplicateData
{
    public Vector3 Input;
    
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
    public Vector3 Velocity;
    public Quaternion Rotation;
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