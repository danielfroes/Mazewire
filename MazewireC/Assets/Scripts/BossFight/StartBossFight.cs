using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StartBossFight : MonoBehaviour
{
    [SerializeField] private GameObject invisibleWall = null;
    [SerializeField] private Vector2 bossFightCamera;
    [SerializeField] private Animator klypAnim;
    private Fog.Dialogue.DialogueHandler dialogueHandler;
   
    void Start()
    {
        dialogueHandler = GetComponent<Fog.Dialogue.DialogueHandler>();
    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
           TriggerBossFight();

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        { 
            // Debug.Log("teste");
            dialogueHandler.Skip();
        }
    }
    private void TriggerBossFight()
    {
        CameraMovement.isCameraFollowingPlayer = false;
        CameraMovement.cameraPosition = bossFightCamera;
        invisibleWall.SetActive(true);

        PlayerMovement.playerCanMove = false;
        klypAnim.SetTrigger("EnterBossArea");

        GetComponent<Fog.Dialogue.DialogueHandler>().StartDialogue();
            
      
        
        //gameObject.SetActive(false);
        
    }       
}
