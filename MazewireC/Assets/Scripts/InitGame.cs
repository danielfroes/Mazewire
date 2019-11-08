using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    private Fog.Dialogue.DialogueHandler dialogueHandler;
    private PlayerController player;
    [SerializeField] private GameObject timeline;
    [SerializeField] private GameObject hearts;
    

    // Start is called before the first frame update
    void Start()
    {
        player =  FindObjectOfType<PlayerController>();
        player.canMove = false;
        player.canAttack = false;
        hearts.SetActive(false);
        dialogueHandler = GetComponent<Fog.Dialogue.DialogueHandler>();
        dialogueHandler.OnDialogueStart += StartFading;
        dialogueHandler.OnDialogueEnd += StartGame; 
        dialogueHandler.StartDialogue();
       

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            dialogueHandler.Skip();
        }
    }
    
    private void StartGame()
    {
        dialogueHandler.OnDialogueEnd -= StartGame; 
        player.canMove = true;
        gameObject.SetActive(false);
    }

    private void StartFading()
    {
        timeline.SetActive(true);
        // GetComponent<Animator>().SetTrigger("dialogueStarted");
        dialogueHandler.OnDialogueStart -= StartFading;
    }

    public void StartGameplay()
    {
        player.canAttack = true;
        player.canMove = true;
        hearts.SetActive(true); 
    }
}
