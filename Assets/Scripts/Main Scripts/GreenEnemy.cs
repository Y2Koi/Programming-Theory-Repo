using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class GreenEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        // POLYMORPHISM
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        speed = 10.0f;
        destroyScore = 60;
        missScore = 30;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
}