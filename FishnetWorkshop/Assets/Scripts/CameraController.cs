using FishNet.Object;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    // Start is called before the first frame update
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner)
        {
            var cameraGameObject = gameObject.GetComponentInChildren<Camera>().gameObject;
            cameraGameObject.SetActive(true);
        }
    }
}
