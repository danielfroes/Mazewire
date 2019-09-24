using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHack : MonoBehaviour
{

    private StartHacking canvas;
    [SerializeField] private int qttOfLetter;
    void Start()
    {
        canvas = FindObjectOfType<StartHacking>();
    }
    

    void Update()
    {
       
    }
    void OnTriggerStay2D(Collider2D col)
    {

        if(col.name == "Aly" &&  Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("teste");
            canvas.StartHack(qttOfLetter);
        }
    }
    


}
