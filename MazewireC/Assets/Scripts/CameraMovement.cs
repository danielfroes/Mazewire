using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target = null;
	public float smoothSpeed = 0.125f;
	[SerializeField] private Vector3 offset;
    public  Vector2 cameraPosition;
    public  bool isCameraFollowingPlayer = true;

    // public bool bounds;
    // public Vector3 minCameraPos;
    // public Vector3 maxCameraPos;

    // Start is called before the first frame update
    void Start(){
        // offset = new Vector3(0, transform.position.y , 0);
    }

    // Update is called once per frame
    void FixedUpdate(){

        if(isCameraFollowingPlayer)
        {  
            Vector3 desiredPosition 	= new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10);
            Vector3 smoothedPosition 	= Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z);
        }

        // if(bounds){

        //     transform.position = new Vector3(

        //         Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
        //         Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
        //         Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z)

        //     );

        // }

    }
  
    // public static Vector2 cameraPosition;
    // [SerializeField]  private GameObject Player = null;
    // private float yOffset;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     yOffset = transform.position.y;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(isCameraFollowingPlayer)
    //     { 
    //        transform.position = new Vector3(Player.transform.position.x,
    //                                         yOffset.position.y + Player.transform.position.y,
    //                                         0); 
    //     }
    //     else
    //     {
    //         transform.position = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z);
    //     }

    // }



// public class Camera_Follow : MonoBehaviour
// {

// 	
// }
}
