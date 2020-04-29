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

    private float points = 0f;

    void Start()
    {
        points = 0f;

        gameOver = false;

        player = GetComponent<Rigidbody2D>();

        score.text = points.ToString();
    }

    void FixedUpdate()
    {
        if (!gameOver)
        {
            points += Time.fixedDeltaTime;
            score.text = points.ToString("F2");
        }

        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = player.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -screenHalfWidth, screenHalfWidth);

        player.MovePosition(newPosition);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Treat")
        {
            points += 1f;
        } else if (other.gameObject.tag == "Slow")
        {
            GameManager.Instance.SetGravityScale(1f);
        } else
        {
            gameOver = true;
            GameManager.Instance.HandleEndGame();
        }
    }
}
