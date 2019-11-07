 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{



    [SerializeField] private int totalHealth= 3;
    private int health;
    public bool inCombat = true;
    [SerializeField] private HealthHeartsUI heartsUI;

    // Start is called before the first frame update
    void Start()
    {
        health = 2;
        heartsUI.DrawHearts(health, totalHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(!inCombat)
        {
            
        }
    }

    public void TakeDamage()
    {
        health --;
        // heartsUI.DrawHearts(health, totalHealth);
    }

}
