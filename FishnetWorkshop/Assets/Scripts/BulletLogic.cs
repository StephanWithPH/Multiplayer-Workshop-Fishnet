using System;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    float moveSpeed = 10f;
    float bulletLifetime = 5f;
    
    void Start() {
        Destroy(gameObject, bulletLifetime);
    }

    void Update() {
        Move();
    }

    void Move() {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}
