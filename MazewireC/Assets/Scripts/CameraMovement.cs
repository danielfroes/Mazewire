using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public static bool isCameraFollowingPlayer = true;
    public static Vector2 cameraPosition;
    [SerializeField]  private GameObject Player = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isCameraFollowingPlayer)
        { 
           transform.position = new Vector3(Player.transform.position.x,
                                            transform.position.y,
                                            transform.position.z); 
        }
        else
        {
            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z);
        }

    }
}
