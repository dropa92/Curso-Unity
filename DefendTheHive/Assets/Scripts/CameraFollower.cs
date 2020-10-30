using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
   
	public static CameraFollower sharedInstance;

	public GameObject followTarget; 	//Target of the camera follows

	public float movementSmoothness = 1.0f;	//Movement of the camera
	public float rotationSmoothness=1.0f;	//Rotation of the camera

	public  bool canFollow=true;






	private void Awake()
	{
	
		sharedInstance=this;

	
	}
		





	private void LateUpdate(){

		if(followTarget==null || canFollow==false){
		return;
		}
		
		//This line moves the camera to the point where is the target with a smooth movement
		transform.position=Vector3.Lerp(this.transform.position, followTarget.transform.position, Time.deltaTime*movementSmoothness);

		//this lines rotates the camera to the point where is the target with a smooth rotation
		transform.rotation=Quaternion.Slerp(this.transform.rotation, followTarget.transform.rotation, Time.deltaTime*rotationSmoothness);
		

	}

}
