using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody enemyRb;
    protected GameObject player;
    protected int lowerBound = -22;
    protected Vector3 forwardDirection;

    public float speed = 1.0f;
    public int destroyScore = 20;
    public int missScore = 5;

    protected virtual void EnemyMovement()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.x = 0; // Ignore vertical difference

        // Check if the enemy is within the stop distance
        if (transform.position.z >= -16.5f)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            forwardDirection = directionToPlayer.normalized; // Update forward direction
        }
        else
        {
            // Move forward in the last known direction
            transform.position += forwardDirection * speed * Time.deltaTime;
            SubtractScore();
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            GameManager.Instance.gameOver = true;
            DestroyObjects(other);
        }
        else if (!other.gameObject.CompareTag("Enemy"))
        {
            DestroyObjects(other);
            AddScore();
        }
    }

    protected void DestroyObjects(Collider otherObject)
    {
        // Just deactivate the projectile and destroy the enemy
        otherObject.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    // ABSTRACTION
    protected void AddScore()
    {
        if (GameManager.Instance.gameOver == false)
        {
            GameManager.Instance.Score += destroyScore;
            GameManager.Instance.scoreText.text = "Score: " + GameManager.Instance.Score;
            GameManager.Instance.CheckHighScore();
        }
    }

    protected void SubtractScore()
    {
        if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            if (GameManager.Instance.gameOver == false)
            {
                GameManager.Instance.Score -= missScore;
                GameManager.Instance.scoreText.text = "Score: " + GameManager.Instance.Score;
                GameManager.Instance.CheckHighScore();
            }
        }
    }
}