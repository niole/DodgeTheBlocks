using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public float rampRate = 0.05f;

    void Start ()
    {
        GetComponent<Rigidbody2D>().gravityScale += (Time.timeSinceLevelLoad * rampRate);
    }

    void Update()
    {
        if (transform.position.y < -3f)
        {
            // destroy
            Destroy(gameObject);
        }
    }
}
