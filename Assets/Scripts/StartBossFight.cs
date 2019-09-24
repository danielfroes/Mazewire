using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFight : MonoBehaviour
{
    [SerializeField] private GameObject invisibleWall = null;
    [SerializeField] private Vector2 bossFightCamera;
    [SerializeField] private Animator klypAnim;
    void OnTriggerEnter2D(Collider2D col)
    {
    
        TriggerBossFight();

    }

    private void TriggerBossFight()
    {
        CameraMovement.isCameraFollowingPlayer = false;
        CameraMovement.cameraPosition = bossFightCamera;
        invisibleWall.SetActive(true);

        PlayerMovement.playerCanMove = false;
        klypAnim.SetTrigger("EnterBossArea");
        // triggar dialogo, trigar animação
    
        gameObject.SetActive(false);
        
    }       
}
