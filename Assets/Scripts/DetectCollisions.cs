using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            DestroyObjects(other);
        }
        else if (!(gameObject.CompareTag("Enemy") && other.gameObject.CompareTag("Enemy")))
        {
            DestroyObjects(other);
        }
    }

    void DestroyObjects(Collider otherObject)
    {
        // Just deactivate the projectile and destroy the enemy
        otherObject.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}