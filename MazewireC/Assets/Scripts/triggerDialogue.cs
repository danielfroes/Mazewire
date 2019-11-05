using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDialogue : MonoBehaviour
{

    private Fog.Dialogue.DialogueHandler dialogueHandler;
    // Start is called before the first frame update
    void Start()
    {
        dialogueHandler = GetComponent<Fog.Dialogue.DialogueHandler>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
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
}
