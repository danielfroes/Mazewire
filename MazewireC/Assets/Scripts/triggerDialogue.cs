using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDialogue : MonoBehaviour
{

    protected Fog.Dialogue.DialogueHandler dialogueHandler;
    protected PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType <PlayerController>();
        dialogueHandler = GetComponent<Fog.Dialogue.DialogueHandler>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            player.canMove = false;
            player.canAttack = false;
            dialogueHandler.OnDialogueEnd += ReturnPlayerMovement;
            dialogueHandler.StartDialogue();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            dialogueHandler.Skip();
        }
    }

    void ReturnPlayerMovement()
    {
        player.canMove = true;
        player.canAttack = true;
        dialogueHandler.OnDialogueEnd -= ReturnPlayerMovement;
        gameObject.SetActive(false);
    }

  
}
