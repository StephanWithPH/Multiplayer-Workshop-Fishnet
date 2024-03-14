using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Object;
using LiteNetLib;
using UnityEngine;
using UnityEngine.UI;

public class HudController : NetworkBehaviour
{
    [SerializeField]
    private Button disconnectButton;

    private void Start()
    {
        disconnectButton.onClick.AddListener(() => Disconnect());
    }

    [ServerRpc(RequireOwnership = false)]
    private void Disconnect()
    {
        Owner.Disconnect(false);
    }
}
