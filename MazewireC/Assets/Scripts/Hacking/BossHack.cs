﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHack : TriggerHacking
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EndHacking()
    {   
        Debug.Log("Dano no boss!!!!");
    }
}
