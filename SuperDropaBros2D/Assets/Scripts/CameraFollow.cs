using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target;                                    //This variable is the target that the camera has to follow
    public Vector3 offset = new Vector3(0.1f, 7.0f, -10);       //Distance from where the camera follow the player
    public float dampTime = 0.3f;                               //Time passed before the camera begins to mover itself
    public Vector3 velocity = Vector3.zero;                     //movement's velocity of the camera












    // Start is called before the first frame update
    private void Awake()
    {
        //Number of frames of the game
        Application.targetFrameRate = 60;
    }

    









    //Reset the camera without SmoothDamp()
    public void ResetCameraPosition()
    {
        //coordenates of the Target's point translated to camera's coordenates  
        //Vector3 pointToMove = GetComponent<Camera>().WorldToViewportPoint(target.position);

        //coordenates of the Target position less the camera's coordenates in the world of the target
      //  Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(offset.x, offset.y, pointToMove.z));

	//Destination to go
        //Vector3 destination = pointToMove + delta;
	
	//Set a destination
        Vector3 destination = new Vector3(target.position.x, offset.y, offset.z);
	
	//Set the camera's position at the destination to go
        this.transform.position = destination;
    }











    // Update is called once per frame

    void Update()
    {
        //coordenates of the Target's point translated to camera's coordenates  
        Vector3 pointToMove = GetComponent<Camera>().WorldToViewportPoint(target.position);

        
        Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(offset.x, offset.y, pointToMove.z));

        Vector3 destination = pointToMove + delta;
        
        destination = new Vector3(target.position.x, offset.y, offset.z);

        this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dampTime);
    
    }
}
