using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klyp : MonoBehaviour
{


    [HideInInspector]public Animator anim;
    public GameObject swords;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {   
        //
        anim.SetBool("isAttacking", true);
        Instantiate(swords, transform);
        // swords.SetActive(true);
    }
}
