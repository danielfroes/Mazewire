using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TriggerHacking : MonoBehaviour
{

    private Hacking hacking;
    [SerializeField] private int qttOfLetter;


    void Start()
    {
        hacking = FindObjectOfType<Hacking>();
    }
    
    void Update()
    {
       
    }
    void OnTriggerStay2D(Collider2D col)
    {

        if(col.tag == "Player" &&  Input.GetKeyDown(KeyCode.E) && !Hacking.isHacking)
        {
            
            hacking.StartHacking(qttOfLetter,this);
           
        }
    }
    
    public abstract void EndHacking();


    

}
