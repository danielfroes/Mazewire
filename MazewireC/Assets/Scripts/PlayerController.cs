using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 10f;
    public float jumpForce = 8f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float dashSpeed = 20f;

    public bool isGrounded;
    public bool hasDashed;
    public bool canMove = true;

    public Transform groundCheck;
    public Transform groundCheckL;
    public Transform groundCheckR;
    

    private SpriteRenderer spriteR;
    [HideInInspector] public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))   ||
          (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
          (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
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

        anim.SetBool("isJumping", !isGrounded);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Q) && !hasDashed && canMove)
        {
            if(xRaw != 0 || yRaw != 0)
                Dash(xRaw, yRaw);
        }

        if(rb.velocity.y < 0 && canMove)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Z) && canMove)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);

        if(Mathf.Abs(rb.velocity.x) >= 0.5f)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
        
        if(rb.velocity.x > 0)
            spriteR.flipX = false;
        else if(rb.velocity.x < 0)
            spriteR.flipX = true;
    
    }   

    private void Jump()
    {
        
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
}
