using FishNet.Object;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject camera;

    private GameObject globalCam;
    private bool toggledGlobalCam = true;

    public override void OnStartClient()
    {
        globalCam = GameObject.FindWithTag("GlobalCamera"); //GameObject.FindGameObjectsWithTag("GlobalCamera");
        globalCam.SetActive(true);
        
        base.OnStartClient();
        if (IsOwner)
        {
            camera.SetActive(false);
        }
    }

    public void OnToggleCamera() {
        if(IsOwner){
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
}
