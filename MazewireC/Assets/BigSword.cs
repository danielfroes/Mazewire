using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSword : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private bool startFalling;
    [SerializeField] private float gravity;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startFalling)
        {
            rb2d.AddForce(Vector2.down * gravity );
        }
    }

    public void StartFall()
    {
        startFalling = true;
    }







}
