using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject block;

    public GameObject treat;

    public float treatRate = 0.1f;

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
                bool shouldTreat = Random.Range(0, 100) <= treatRate*100;
                if (shouldTreat)
                {
                    Instantiate(treat, spawnPoints[i].position, Quaternion.identity);
                } else
                {
                    // spawn normal block
                    Instantiate(block, spawnPoints[i].position, Quaternion.identity);
                }
            }
        }
    }

}
