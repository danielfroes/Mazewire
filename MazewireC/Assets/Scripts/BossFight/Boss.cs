using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{


    static public bool firstState = true;
    private bool coroutineRunning = false;
    [SerializeField] private Animator bossAnim;
    [SerializeField] private GameObject bigSword;
    private bool blinking = false;
    private float spriteBlinkingTimer;
    public float spriteBlinkingMiniDuration = 0.1f;
    private float spriteBlinkingTotalTimer;
    public float spriteBlinkingTotalDuration = 1;
    private SpriteRenderer spriteRenderer;
    public int health = 3;
    private PlayerLife player;

    [SerializeField] private GameObject EndCutscene;
    // Start is called before  the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerLife>();
    }
    // Update is called once per frame
    void Update()
    {   
        player.inCombat = true;
        if (firstState)
        {
            if(!coroutineRunning)
            {
                StartCoroutine(FirstState());
            }
        }

        if(blinking)
        {
            SpriteBlinkingEffect();
        }

    }


    public IEnumerator FirstState()
    {   Random rnd = new Random();
        coroutineRunning = true;
        for(int i = 0; i < Random.Range(1,2); i++ )
        {
            yield return new WaitForSecondsRealtime(bossAnim.GetCurrentAnimatorStateInfo(0).length );
        }
        
        bossAnim.SetTrigger("TransitionToAttackTrigger");
    
        yield return new WaitForSecondsRealtime(bossAnim.GetCurrentAnimatorStateInfo(0).length );
        bossAnim.SetBool("isAttacking", true);
        bossAnim.SetInteger("Attack",Random.Range(1,4));
        // bossAnim.SetInteger("Attack",3);
        yield return new WaitForSecondsRealtime(bossAnim.GetCurrentAnimatorStateInfo(0).length );

        coroutineRunning = false;
        bossAnim.SetInteger("Attack",0);    
    }


    public void EndAttackEvent()
    {
        bossAnim.SetBool("isAttacking", false);
    }

    public void SpawnBigSword()
    {
        GameObject instanceSword = Instantiate(bigSword);
        instanceSword.transform.position = new Vector3(transform.position.x, transform.position.y - 2.5f, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag == "Player" && player.isVunerable)
        {
            player.TakeDamage();
        }
    }

    public void TakeDamage()
    {
        blinking = true;
        health--;
        if(health == 0)
        {
            EndBossFight();
        }
    }    


    void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            blinking = false;

            spriteBlinkingTotalTimer = 0.0f;
            spriteRenderer.enabled = true;
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

    void EndBossFight()
    {
        FindObjectOfType<PlayerController>().canMove = false;
        FindObjectOfType<PlayerController>().canAttack = false;
        EndCutscene.SetActive(true);
        gameObject.SetActive(false);
    }
}
