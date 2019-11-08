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
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private PlayerLife playerLife;
    Rigidbody2D rb;
    private bool goingRight = true;
   
    [SerializeField] private bool isArena = false;
    [SerializeField] private TriggerCombatSession combatManager; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerLife = FindObjectOfType<PlayerLife>();
        facingRight = false;
    }

    void Update()
    {
        // died
        

        // took damage
        if(blinking)
        {
            SpriteBlinkingEffect();
        }

        // movement
        float playerDistance = Vector2.Distance(player.position, transform.position);
        if(health <= 0)
        {
            
            if(isArena)
                combatManager.enemiesQtt --;
            
            playerLife.inCombat = false;
            
            Destroy(gameObject);
        }
        else if(playerDistance < 15f)
        {
            anim.SetBool("isWalking",true);
            playerLife.inCombat = true;
            if(player.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else if(player.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            // transform.position =  Vector2.MoveTowards(
            //     transform.position,
            //     new Vector2(player.position.x, transform.position.y),
            //     speed * Time.deltaTime
            // );
        }
        else
        {
            playerLife.inCombat = false;
            anim.SetBool("isWalking", false);
        }

        // flip sprite
        var side = player.position.x - transform.position.x;
        if(!facingRight && side > 0)
        {
            // Debug.Log("fliping to face right");
            Flip();
        }
        else if(facingRight && side < 0)
        {
            // Debug.Log("fliping to face left");
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Aly")
        {
            playerLife.TakeDamage();
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
            spriteRenderer.enabled = true;
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if(spriteRenderer.enabled == true)
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                spriteRenderer.enabled = true;
            }
        }
    }
}
