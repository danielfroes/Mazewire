using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health; //80

    // movement:
    public float speed; //4
    private bool facingRight;
    public Transform player;

    // damage effect:
    private float spriteBlinkingTimer;
    public float spriteBlinkingMiniDuration; //0.1
    private float spriteBlinkingTotalTimer;
    public float spriteBlinkingTotalDuration; //1
    private bool blinking;

    Rigidbody2D rb;
    private bool goingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = false;
    }

    void Update()
    {
        // died
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        // took damage
        if(blinking)
        {
            SpriteBlinkingEffect();
        }

        // movement
        float playerDistance = Vector2.Distance(player.position, transform.position);
        if(playerDistance < 10f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(player.position.x, transform.position.y),
                speed * Time.deltaTime
            );
        }

        // flip sprite
        var side = player.position.x - transform.position.x;
        if(!facingRight && side > 0)
        {
            Debug.Log("fliping to face right");
            Flip();
        }
        else if(facingRight && side < 0)
        {
            Debug.Log("fliping to face left");
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Aly")
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void TakeDamage(int damage)
    {
        blinking = true;
        health -= damage;
    }

    void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            blinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if(gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
