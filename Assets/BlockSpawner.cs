using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject block;

    public GameObject treat;

    public GameObject slower;

    public float slowRate = 0.05f;

    public float treatRate = 0.1f;

    private float spawnInterval = 2f;

    private float timeOffset = 0f;

    public float rampRate = 0.05f;

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
        float nextScale = GameManager.Instance.IncrementGravityScale(Time.deltaTime * rampRate);
        Debug.Log(nextScale);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomIndex)
            {
                bool shouldTreat = ShouldHappen(treatRate);
                bool shouldSlow = ShouldHappen(slowRate);
                GameObject newObject;
                if (shouldSlow)
                {
                    newObject = Instantiate(slower, spawnPoints[i].position, Quaternion.identity);
                } else if (shouldTreat)
                {
                    newObject = Instantiate(treat, spawnPoints[i].position, Quaternion.identity);
                } else
                {
                    // spawn normal block
                    newObject = Instantiate(block, spawnPoints[i].position, Quaternion.identity);
                }
                newObject.GetComponent<Rigidbody2D>().gravityScale = nextScale;
            }
        }
    }

    bool ShouldHappen(float rate)
    {
        return Random.Range(0, 100) <= rate*100;
    }

}
