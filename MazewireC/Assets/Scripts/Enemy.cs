using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public int timeBeforeChangingDirection;
    private int timeBeforeChangingDirectionCounter;

    Rigidbody2D rb;
    private bool goingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeBeforeChangingDirectionCounter = timeBeforeChangingDirection;
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if(goingRight)
        {
            rb.velocity = Vector2.right * speed;
            timeBeforeChangingDirectionCounter -= 1;
        }
        else
        {
            rb.velocity = Vector2.left * speed;
            timeBeforeChangingDirectionCounter -= 1;
        }
        if(timeBeforeChangingDirectionCounter <= 0)
        {
            timeBeforeChangingDirectionCounter = timeBeforeChangingDirection;
            goingRight = !goingRight;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Aly")
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
