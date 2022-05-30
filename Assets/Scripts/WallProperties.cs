using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallProperties : MonoBehaviour
{
    public bool isLeft;
    public bool isScoreArea;
    private float bounceStrength = 0.5f;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D ball;
        if(collision.collider.tag == "Ball")
        {
            ball = collision.gameObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            return;
        }
        if (isLeft && isScoreArea)
        {
            gameManager.ComputerScores();
        }
        else if (!isLeft && isScoreArea)
        {
            gameManager.PlayerScores();
        }
        if (!isScoreArea)
        {
            if (ball != null)
            {
                Vector2 normal = collision.GetContact(0).normal;
                ball.AddForce(-normal * bounceStrength, ForceMode2D.Impulse);
            }
        }
    }
}
