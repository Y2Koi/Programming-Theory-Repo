using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    public override void FollowPlayer()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.x = 0; // Ignore vertical difference

        // Check if the enemy is within the stop distance
        if (transform.position.z >= -16.5f)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 10 * Time.deltaTime);
            forwardDirection = directionToPlayer.normalized; // Update forward direction
        }
        else
        {
            // Move forward in the last known direction
            transform.position += forwardDirection * 10 * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
}