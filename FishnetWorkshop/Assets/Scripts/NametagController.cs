using System;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using TMPro;
using UnityEngine;

public class NametagController : NetworkBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    
    [HideInInspector]
    [SyncVar]
    private string networkedPlayerName;
    
    private TMP_Text messageText;
    
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner)
        {
            SetPlayerName(playerData.playerName);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        messageText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        messageText.SetText(networkedPlayerName);
    }

    [ServerRpc(RequireOwnership = true)]
    private void SetPlayerName(string name)
    {
        networkedPlayerName = name;
    }
}
