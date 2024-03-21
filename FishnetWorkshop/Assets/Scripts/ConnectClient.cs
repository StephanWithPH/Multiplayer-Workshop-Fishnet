using System.Collections;
using System.Collections.Generic;
using FishNet;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectClient : MonoBehaviour
{
    public PlayerData playerData;
    
    public void ToClientScene()
    {
        if (!string.IsNullOrWhiteSpace(playerData.playerName))
        {
            InstanceFinder.ClientManager.StartConnection();
        }
    }

    public void PlayerNameInput(string name)
    {
        playerData.playerName = name;
    }

    
}
