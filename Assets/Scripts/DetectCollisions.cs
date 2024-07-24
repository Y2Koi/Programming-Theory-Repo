using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Just deactivate the projectile and destroy the enemy
        other.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}