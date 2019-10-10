using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{


    static public bool firstState = true;
    public bool coroutineRunning = false;
    [SerializeField] private Animator bossAnim;

    // Start is called before the first frame update

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
        for(int i = 0; i < 3; i++ )
        {
            yield return new WaitForSecondsRealtime(bossAnim.GetCurrentAnimatorStateInfo(0).length );
        }

        bossAnim.SetTrigger("TransitionToAttackTrigger");
    
        yield return new WaitForSecondsRealtime(bossAnim.GetCurrentAnimatorStateInfo(0).length );
        
        bossAnim.SetInteger("Attack",Random.Range(1,3));

        yield return new WaitForSecondsRealtime(bossAnim.GetCurrentAnimatorStateInfo(0).length );

        coroutineRunning = false;
        bossAnim.SetInteger("Attack",0);    
    }
}
