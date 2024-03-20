using System.Collections;
using System.Collections.Generic;
using FishNet;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectClient : MonoBehaviour
{
    
    public void ToClientScene()
    {
        InstanceFinder.ClientManager.StartConnection();
    }

    
}
