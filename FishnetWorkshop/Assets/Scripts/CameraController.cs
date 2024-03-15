using FishNet.Object;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject camera;
    
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner)
        {
            camera.SetActive(true);
        }
    }
}
