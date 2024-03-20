using System;
using FishNet.Object;
using NUnit.Framework.Constraints;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject camera;

    private GameObject globalCam;
    private bool toggledGlobalCam = false;

    void Start() {
        globalCam = GameObject.FindGameObjectWithTag("GlobalCamera");
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner)
        {
            camera.SetActive(true);
        }
    }

    public void OnToggleCamera() {
        if(toggledGlobalCam){
            camera.SetActive(true);
            globalCam.SetActive(false);
        } else{
            camera.SetActive(false);
            globalCam.SetActive(true);
        }

        toggledGlobalCam = !toggledGlobalCam;
    }
}
