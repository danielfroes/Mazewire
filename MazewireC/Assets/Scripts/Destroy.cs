using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    [SerializeField] private GameObject boss;
    // Start is called before the first frame update
    public void DestroyObject()
    {
        FindObjectOfType<PlayerController>().canMove = true;
        Instantiate(boss);
        gameObject.SetActive(false);
    }
}
