using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{


    static public bool firstState = true;
    private bool coroutineRunning = false;
    [SerializeField] private Animator bossAnim;
    [SerializeField] private GameObject bigSword;

    private PlayerLife player;
    // Start is called before  the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerLife>();
    }
    // Update is called once per frame
    void Update()
    {   
        
        if (firstState)
        {
            if(!coroutineRunning)
            {
                StartCoroutine(FirstState());
            }
        }
    }


    public IEnumerator FirstState()
    {   Random rnd = new Random();
        coroutineRunning = true;
        for(int i = 0; i < Random.Range(1,4); i++ )
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
    
}
