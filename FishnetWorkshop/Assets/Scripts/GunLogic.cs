using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

public class GunLogic : NetworkBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;

    void OnFire()
    {
        if (IsOwner)
        {
            Shoot();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void Shoot(NetworkConnection client = null)
    {
        GameObject bull = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Spawn(bull, client);
    }
}
