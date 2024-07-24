using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 2;
    private float lowerBound = -22;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            //Deactivate the GameObject
            gameObject.SetActive(false);

        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}