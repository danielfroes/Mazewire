using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    static public bool playerCanMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        // float yInput = Input.GetAxis("Vertical");
        if(playerCanMove)
            rb.velocity = new Vector2(xInput*speed*Time.deltaTime , 0f);
        else if (!playerCanMove)
            rb.velocity = new Vector2(0f, 0f);
    }
}
