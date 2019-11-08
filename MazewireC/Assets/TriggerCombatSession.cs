using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCombatSession : MonoBehaviour
{
    // Start is called before the first frame update

    public int enemiesQtt;
    [SerializeField] private GameObject toEnable;
    private Collider2D triggerCol;

    [SerializeField] private GameObject cameraPlayer;
    [SerializeField] private GameObject cameraScene;

    [SerializeField] private Fog.Dialogue.DialogueHandler dialogueHandlerBefore;
    [SerializeField] private Fog.Dialogue.DialogueHandler dialogueHandlerAfter;
    private PlayerController player;     
    
    void Start()
    {
        player = FindObjectOfType <PlayerController>();
        dialogueHandlerBefore = GetComponent<Fog.Dialogue.DialogueHandler>();
       
        triggerCol = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            player.canMove = false;
            player.canAttack = false;
            cameraPlayer.SetActive(false);
            cameraScene.SetActive(true);
            dialogueHandlerBefore.OnDialogueEnd += ReturnPlayerMovement;
            dialogueHandlerBefore.OnDialogueEnd += StartCombat;
            dialogueHandlerBefore.StartDialogue();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            dialogueHandlerBefore.Skip();
            dialogueHandlerAfter.Skip();
        }

        if(enemiesQtt == 0)
        {
            enemiesQtt --;
            player.canMove = false;
            player.canAttack = false;
            cameraPlayer.SetActive(true);
            cameraScene.SetActive(false);
            toEnable.SetActive(false);
            dialogueHandlerAfter.OnDialogueEnd += ReturnPlayerMovementAfter;
            dialogueHandlerAfter.StartDialogue();
        }
    }

    void ReturnPlayerMovement()
    {
        player.canMove = true;
        player.canAttack = true;
        dialogueHandlerBefore.OnDialogueEnd -= ReturnPlayerMovement;

    }
   
    void ReturnPlayerMovementAfter()
    {
        player.canMove = true;
        player.canAttack = true;
        dialogueHandlerAfter.OnDialogueEnd -= ReturnPlayerMovement;

    }


    public void StartCombat()
    {
        toEnable.SetActive(true);
        triggerCol.enabled = false;
        dialogueHandlerBefore.OnDialogueEnd -= StartCombat;

    }
}
