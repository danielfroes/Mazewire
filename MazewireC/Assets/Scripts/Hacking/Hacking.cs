using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : MonoBehaviour
{
    public static bool isHacking = false;
    [SerializeField] private float letterWidth;
    private int letterCnt = 0;
    private TriggerHacking hackTrigger;
    private Letter letterToHack = null;
    public Letter[] possibleLetters;
    public Queue<Letter> letterQueue;
    private Queue<Letter> lettersToErase;
    void Start()
    {
        letterQueue = new Queue<Letter>();
        lettersToErase = new Queue<Letter>();
    }
    
    public void StartHacking(int qttOfLetter, TriggerHacking hackTrigger)
    {   
        PlayerController.canMove = false;   
        this.hackTrigger = hackTrigger.GetComponent<TriggerHacking>();
        float xPos = -0.5f * (qttOfLetter - 1)* letterWidth; //first Letter position
        
        
        for(int i = 0; i < qttOfLetter; i++)
        {
            spawnLetter(possibleLetters[Random.Range(0,4)], xPos);
            xPos += letterWidth;
        }
        isHacking = true;
    }

    private void spawnLetter(Letter letter, float xPos)
    {
        Letter letterI =  Instantiate<Letter>(letter, transform);
        letterI.imageComponent.sprite = letterI.notPressedSprite;
        letterI.imageComponent.rectTransform.anchoredPosition = new Vector3( xPos, 0, 0);
        letterCnt ++;
        letterQueue.Enqueue(letterI);
    }

    // Update is called once per frame
    void Update()
    {
        if(isHacking)
        {
            if(letterToHack == null)
            {
                if(letterQueue.Count == 0)
                {
                    EndHacking();
                }
                else
                {
                    letterToHack = letterQueue.Dequeue();
                }
            }
            else if(Input.GetKeyDown(letterToHack.key))
            {
                letterToHack.imageComponent.sprite = letterToHack.pressedSprite;
                lettersToErase.Enqueue(letterToHack); //adiciona a letra acertada na lista para apagar
                letterToHack = null;
            }
            
        }   
    }

    void EndHacking()
    {

        //limpar a tela 
        isHacking = false;
        while(lettersToErase.Count != 0)
        {   
            Destroy(lettersToErase.Dequeue().gameObject);
        }
        PlayerController.canMove = true;
        hackTrigger.EndHacking();
    }

    


}


