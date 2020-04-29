using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Destroyer : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y < -3f)
        {
            // destroy
            Destroy(gameObject);
        }
    }

}
