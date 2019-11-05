using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    public float speed;
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float dashSpeed;

    private bool facingRight = true;
    public bool isGrounded;
    public bool hasDashed;
    public bool canMove = true;

    public LayerMask whatIsEnemies;
    public Transform attackPosition;
    public Transform groundCheck;
    public Transform groundCheckL;
    public Transform groundCheckR;

    [HideInInspector]public Animator anim;
    private Klyp klyp;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        klyp = FindObjectOfType<Klyp>();
    }

    private void FixedUpdate()
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))   ||
          (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
          (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            anim.SetBool("isJumping", false);
            isGrounded = true;
            hasDashed = false;
        }
        else
        {
            isGrounded = false;
        }

      
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        
        if(canMove)
        { 
            Walk(new Vector2(xRaw, yRaw));
        }
        else if(!canMove && !hasDashed)
        {
            Walk(new Vector2(0,0));
        } 
        // jump:
        if(isGrounded && Input.GetKeyDown(KeyCode.Z) && canMove)
        {
            Jump();
        }

        // dash:
        if(Input.GetKeyDown(KeyCode.X) && !hasDashed && canMove)
        {
            if(xRaw != 0 || yRaw != 0)
                Dash(xRaw, yRaw);
        }

        // attack:
        if(timeBetweenAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.C)){
                Attack();
                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }

        // velocity update:
        if(rb.velocity.y < 0 && canMove)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Z) && canMove)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPosition.position, new Vector3(attackRangeX, attackRangeY, 1));
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);

        if(Vector2.SqrMagnitude(rb.velocity) >= 0.5f)
        {
            klyp.anim.SetBool("isWalking",true);
            anim.SetBool("isRunning", true);
        }
        else
        {
            klyp.anim.SetBool("isWalking",false);
            anim.SetBool("isRunning", false);
        }
        if(!facingRight && dir.x > 0)
        {
            Flip();
        }
        else if(facingRight && dir.x < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Jump()
    {   
        anim.SetBool("isJumping", true);
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
    }

    private void Dash(float x, float y)
    {
        hasDashed = true;
        rb.velocity = Vector2.zero;
        Vector2 dir =  new Vector2(x, y);
        rb.velocity += dir.normalized * dashSpeed;
    }

    private void Attack()
    {

        klyp.Attack();
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(
            attackPosition.position,
            new Vector2(attackRangeX, attackRangeY),
            0,
            whatIsEnemies
        );

        for(int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
