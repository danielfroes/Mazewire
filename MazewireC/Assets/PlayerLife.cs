 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private int totalHealth= 3;
    private int health;
    private Animator anim;
    public bool inCombat = false;
    public bool isVunerable = true;
    private bool blinking = false;
    private float spriteBlinkingTimer;
    public float spriteBlinkingMiniDuration; //0.1
    private float spriteBlinkingTotalTimer;
    public float spriteBlinkingTotalDuration; //1
    [SerializeField] private HealthHeartsUI heartsUI;
    private SpriteRenderer spriteRenderer;
    private PlayerController controller;
    [SerializeField] private float secondsToRegen;
    private float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        health = totalHealth;
        heartsUI.DrawHearts(health, totalHealth);
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if(blinking)
        {
            SpriteBlinkingEffect();
        }

        Debug.Log(inCombat);
        if(!inCombat && health < totalHealth)
        {
            
            counter += Time.deltaTime;
            if(counter >= secondsToRegen)
            {
                health ++;
                heartsUI.DrawHearts(health, totalHealth);
                counter = 0;
            }
        }
        else
        {
            counter = 0;
        }
    }

    public void TakeDamage()
    {   
        if(isVunerable)
        {
            anim.SetBool("takenDamage",true);
            health --;
            isVunerable = false;
            blinking = true;
            controller.canAttack = false;
            heartsUI.DrawHearts(health, totalHealth);
        }
    }


    void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            isVunerable = true;
            blinking = false;
            anim.SetBool("takenDamage",false);
            spriteBlinkingTotalTimer = 0.0f;
            spriteRenderer.enabled = true;
            controller.canAttack = true;
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if(spriteRenderer.enabled == true)
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                spriteRenderer.enabled = true;
            }
        }
    }
}
