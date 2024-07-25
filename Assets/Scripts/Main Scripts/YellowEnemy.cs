using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class YellowEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        // POLYMORPHISM
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        speed = 5;
        destroyScore = 40;
        missScore = 20;
}

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
}