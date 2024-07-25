using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private GameManager gameManagerScript;
    private float spawnRangeX = 15.75f;
    private float spawnPosZ = 1;
    private float startDelay = 2;
    private float spawnInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameOver == true)
        {
            CancelInvoke();
        }
    }

    void SpawnRandomEnemy()
    {
        // Randomly generate enemy index and spawn position
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -15.93008f, spawnPosZ);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}