using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHacking : MonoBehaviour
{
    public Letter[] possibleLetters;
    private int letterCnt = 0;

    [SerializeField] private float letterWidth;
    public void StartHack(int qttOfLetter)
    {   
        
        PlayerMovement.playerCanMove = false;   

        float xPos = -0.5f * (qttOfLetter - 1)* letterWidth; //first Letter position
        
        for(int i = 0; i < qttOfLetter; i++)
        {
            spawnLetter(possibleLetters[Random.Range(0,4)], xPos);
            xPos += letterWidth;
        }
    }

    private void spawnLetter(Letter letter, float xPos)
    {
        Letter letterI =  Instantiate<Letter>(letter, transform);
        letterI.imageComponent.sprite = letterI.notPressedSprite;
        letterI.imageComponent.rectTransform.anchoredPosition = new Vector3( xPos, 0, 0);
        Debug.Log(letterI.character + " - "+ xPos); 

        
        letterCnt ++;
    }
}

