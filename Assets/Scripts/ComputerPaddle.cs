using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    private float moveSpeed = 3f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>() == null)
        {
            return;
        }
        Rigidbody2D ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        if (ball.velocity.x > 0f)
        {
            if (ball.position.y > rb.position.y)
            {
                rb.AddForce(Vector2.up * moveSpeed);
            }
            else if (ball.position.y < rb.position.y)
            {
                rb.AddForce(Vector2.down * moveSpeed);
            }
        }
        else
        {
            if (rb.position.y > 0f)
            {
                rb.AddForce(Vector2.down * moveSpeed);
            }
            else if (rb.position.y < 0f)
            {
                rb.AddForce(Vector2.up * moveSpeed);
            }
        }
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.position = new Vector2(rb.position.x, 0f);
    }
}
