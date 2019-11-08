using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private Animator klypAnim;
    // // Start is called before the first frame update
    void Start()
    {
        klypAnim = FindObjectOfType<Klyp>().GetComponent<Animator>();
    }

    // Update is called once per frame
    public void EndAttack()
    {
        klypAnim.SetBool("isAttacking", false);
        // FindObjectOfType<PlayerController>().canMove = true;
        Destroy(gameObject);
    }
}
