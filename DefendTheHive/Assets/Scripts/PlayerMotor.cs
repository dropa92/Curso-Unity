﻿using System.Collections;
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
    }


    private bool isOnTheGround;
    //Check the character is at the ground
    void CheckGroundStatus(){
    
    }
	//Move the character
    void Move(Vector3 move){
    
    
    }

    void ApplyExtraRotation(){


    }
}


