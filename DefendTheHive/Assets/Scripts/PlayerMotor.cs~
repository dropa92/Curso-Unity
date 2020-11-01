using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
	float horizontal,vertical;				//Character's movement to ahead, bac, or left, right
	
	Rigidbody m_Rigidbody;					//Character's rigidbody
	
	public float jumpForce, moveSpeed, runSpeed;		//Max speed to jump, move, and run movements

	public float currentJumpForce=0, currentMoveSpeed=0;	//current force of jump and movement

	private Animator m_Animator;				//Character's animation

	private bool isGrounded;




    // Start is called before the first frame update
    void Start()
    {
	m_Rigidbody = GetComponent<Rigidbody>();
	currentMoveSpeed=moveSpeed;
	m_Animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check the character is at the ground
	CheckGroundStatus();


	//Check the amount of movement H/V
	horizontal=CrossPlatformInputManager.GetAxis("Horizontal");
	vertical=CrossPlatformInputManager.GetAxis("Vertical");
	
	//Check to jump
	if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
	
		m_Rigidbody.AddForce(0,jumpForce,0);   
	
	}
	
	//check to run
	if(Input.GetKeyDown(KeyCode.LeftShift)&& isGrounded){
	
		currentMoveSpeed=runSpeed;
	
	}

	//check to stop running
	if(Input.GetKeyUp(KeyCode.LeftShift)){
	
		currentMoveSpeed=moveSpeed;  
	}

    }


    private float turnAround, forwardAmount;		//turning and forward speed
    [SerializeField] float stationaryTurnAround = 180;  //turning 180 degree in one second stopped
    [SerializeField] float movingTurnSpeed= 360;	//turning 360 degree running
    public Transform m_camera;				//Main camera
    private Vector3 cameraForward;			//Camera's target
    private Vector3 move;
    private float jump;
    private Vector3 groundNormal;

    private void FixedUpdate(){
    
	    //If the camera is asignated, moves to the direction where it is looking
    if(m_camera!=null){
     
	    cameraForward=Vector3.Scale(m_camera.forward, new Vector3(1,0,1)).normalized;
	    move = vertical*cameraForward + horizontal*m_camera.right;

    
    }else{

    		//We calculate de absolute coordenates of the world
	    move=vertical*Vector3.forward+horizontal * Vector3.right;
    
    }

    if(move.magnitude>0){
    
    Move(move);
    }
    
    }


    
    //Check the character is at the ground
    void CheckGroundStatus(){
    
    }




	//Move the character
    void Move(Vector3 movement){
   
	   if(movement.magnitude>1.0f){
	   
		//Now we set the lenght to 1
		movement.Normalize();	
	   
	   }

	  movement = transform.InverseTransformDirection(movement); 
	  CheckGroundStatus();

	  //we modificate the movement over the normal vector to the ground which the character is walking
	  movement= Vector3.ProjectOnPlane(movement, groundNormal);

	turnAround=Mathf.Atan2(move.x,move.z);
	  forwardAmount=move.z;
	  m_Rigidbody.velocity = transform.forward * currentMoveSpeed;
	  ApplyExtraRotation();
	   
    
    }

    void ApplyExtraRotation(){


    }
}



