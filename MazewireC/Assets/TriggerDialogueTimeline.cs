using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerDialogueTimeline : triggerDialogue
{


    [SerializeField] private PlayableDirector director;
    // Start is called before the first frame update

    // Update is called once per frame
  

      public void StartDialogueInTimeline()
    {
        //Debug.Log("Texto rodou");
        //director.enabled = false;
        dialogueHandler.StartDialogue();
        //dialogueHandler.OnDialogueEnd += ReactivateTimeline;
    }
    private void ReactivateTimeline()
    {   
        //dialogueHandler.OnDialogueEnd -= ReactivateTimeline;
        //director.enabled = true;       
    }
}
