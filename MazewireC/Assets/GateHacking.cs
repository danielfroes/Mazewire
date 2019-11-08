using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHacking : TriggerHacking
{
  
    [SerializeField] private Animator HackingAnim;
    

    // Start is called before the first frame update


    public override void EndHacking()
    {
        HackingAnim.SetTrigger("OpenGate");
    }



}
