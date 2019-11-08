using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerDialogueEndScene : triggerDialogue
{
    public void StartDialogueInTimeline()
    {
        //Debug.Log("Texto rodou");
        //director.enabled = false;
        dialogueHandler.OnDialogueEnd += EndGame;
        dialogueHandler.StartDialogue(); 
    }
    private void EndGame()
    {   
        dialogueHandler.OnDialogueEnd -= EndGame;
        SceneManager.LoadScene("TelaWinWin");
       
        //director.enabled = true;       
    }
}
