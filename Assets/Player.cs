using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Player : MonoBehaviour
{
    public float speed = 15f;

    public float screenHalfWidth = 9.5f;

    public TextMesh score;

    private Rigidbody2D player;

    private bool gameOver = false;

    void Start()
    {
        gameOver = false;

        player = GetComponent<Rigidbody2D>();

        score.text = "0";
    }

    void FixedUpdate()
    {
        if (!gameOver)
        {
            score.text = $"{Time.timeSinceLevelLoad}";
        }

        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = player.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -screenHalfWidth, screenHalfWidth);

        player.MovePosition(newPosition);
    }

    void OnCollisionEnter2D()
    {
        gameOver = true;
        GameManager.Instance.HandleEndGame();
    }
}
