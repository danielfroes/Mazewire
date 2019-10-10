using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAly : MonoBehaviour
{


    [SerializeField] private GameObject player;
    private Rigidbody2D klypRigidbody;
    private Rigidbody2D alyRigidbody;

    static public bool isFollowingAly = true;

    // Start is called before the first frame update
    void Start()
    {
        alyRigidbody = player.GetComponent<Rigidbody2D>();
        klypRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowingAly)
        {
            klypRigidbody.velocity = alyRigidbody.velocity;
        }
    }
}
