using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        speed = 7.5f;
        destroyScore = 50;
        missScore = 25;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
}