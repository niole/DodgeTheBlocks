using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject block;

    private float spawnInterval = 2f;

    private float timeOffset = 0f;

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeOffset += Time.deltaTime;

        if (timeOffset >= spawnInterval)
        {
            timeOffset = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomIndex)
            {
                // spawn
                Instantiate(block, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }

}
