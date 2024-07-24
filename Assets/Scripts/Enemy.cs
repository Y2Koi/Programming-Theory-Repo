using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody enemyRb;
    protected GameObject player;

    protected Vector3 forwardDirection;

    public virtual void FollowPlayer()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.x = 0; // Ignore vertical difference

        // Check if the enemy is within the stop distance
        if (transform.position.z >= -16.5f)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
            forwardDirection = directionToPlayer.normalized; // Update forward direction
        }
        else
        {
            // Move forward in the last known direction
            transform.position += forwardDirection * Time.deltaTime;
        }
    }
}
