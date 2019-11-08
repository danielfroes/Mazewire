using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StartBossFight : MonoBehaviour
{
    [SerializeField] private GameObject invisibleWall = null;
    [SerializeField] private Vector2 bossFightCamera;
    [SerializeField] private Animator klypAnim;
    private PlayerController player;
    private Fog.Dialogue.DialogueHandler dialogueHandler;
    private CameraMovement camera;
   
    void Start()
    {
        dialogueHandler = GetComponent<Fog.Dialogue.DialogueHandler>();
        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraMovement>();
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
        camera.isCameraFollowingPlayer = false;
        camera.cameraPosition = bossFightCamera;
        
        player.canAttack = false;
        player.canMove = false;
        
        dialogueHandler.StartDialogue();
      
       
        dialogueHandler.OnDialogueEnd += StartBoss;
    }     

    private void StartBoss()
    {
        klypAnim.SetTrigger("EnterBossArea");
        invisibleWall.SetActive(true);
   
        dialogueHandler.OnDialogueEnd -= StartBoss; 
        gameObject.SetActive(false);
    }
}
