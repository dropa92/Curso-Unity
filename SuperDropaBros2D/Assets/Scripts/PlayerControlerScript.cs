﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControlerScript : MonoBehaviour{

    public float jumpForce = 4f;    //Jump's force

    private Rigidbody2D ridgiBody;

    public AudioClip jumpSound;

    public LayerMask groundLayer;   //This variable checks the layer of the ground

    public Animator animator;       //The character's animation

    public float runningSpeed = 6.0f;   //This will be the speed of the character

    public static PlayerControlerScript sharedInstance; //it is used to make a singletone on this class

    public Vector3 initialPosition; //it will be the initial player's position

    private int healthPoints, manaPoints;	//Points to health and mana

    public const int INITIALHEALTH=40, INITIALMANA=40, COST_SUPERJUMP=5;
    
    public const float MIN_SPEED=1.5F, MAX_MANA=40.0F, MAX_HEALTH=40.0F, FORCE_SUPERJUMP=1.5f ;
    


    
    //Before the game starts, the game have to be configured
    void Awake()
    {
        //we do a singletone on this class with this variable
        sharedInstance = this;

        //We reference our rigidBody with the Rigidbody2D in the Scene 
        ridgiBody = GetComponent<Rigidbody2D>();

        //we assign the position when the player starts the game to the variable initialPosition to know its first position
        initialPosition = this.transform.position;
     
	

    }   





    // Start is called before the first frame update
    public void StartGame()
    {   
	    this.healthPoints=INITIALHEALTH;
	    this.manaPoints=INITIALMANA;
        animator.SetBool("isAlive", true);		//This set the character's state to Alive
        animator.SetBool("isGrounded", true);		//this set the character is on the ground
	animator.SetBool("isMoving",false);
        this.transform.position = initialPosition;	//this set the initial position of the character
    }




    // Update is called once per frame
    void Update()
    {

        //If the game is inside of gameplay, the character can jump
        if (GameManager.sharedInstance.currentGameState == GameState.inGame) {

            //Here, we check if the key Space is down, the character jumps
            if (Input.GetKeyDown(KeyCode.Space))
        { animator.SetBool("isJumping",true);

               
            Jump(false);
        }else{
	
	animator.SetBool("isJumping",false);

	}

//Here, we check if the mouse's button zero is down, the character super jumps

	    if (Input.GetMouseButtonDown(0))
        {
               
            Jump(true);
        }



        //Check the character is touching the ground
        animator.SetBool("isGrounded", IsTouchingTheGround());
	
	        }
    }



    //This method is called by Unity every 0.1 second and is very usefull to make movements as run or hit
     void FixedUpdate()
    {

        //If the game is inside of gameplay, the character can move
        if (GameManager.sharedInstance.currentGameState == GameState.inGame) { 
	
	//If the Key D is down
        if (Input.GetKey(KeyCode.D)) {
		animator.SetBool("isMoving",true);

		float currentSpeed=(runningSpeed-MIN_SPEED)*this.healthPoints/MAX_HEALTH;

                if (ridgiBody.velocity.x < currentSpeed)
                {

			
                    
                    //We assing positive speed to the character's movement at the X axis to go right and keep the current speed at the Y axis  
                    ridgiBody.velocity = new Vector2(currentSpeed, ridgiBody.velocity.y);
                
        }
    }





	//If the Key A is down
        if (Input.GetKey(KeyCode.A))
        {	
	animator.SetBool("isMoving",true);

		float currentSpeed=(runningSpeed-MIN_SPEED)*this.healthPoints/MAX_HEALTH;


		//If the character velocity is greater than running speed
            if (ridgiBody.velocity.x > -currentSpeed)
            {
		                    //We assing negative speed to the character's movement at the X axis to go left and keep the current speed at the Y axis  
                ridgiBody.velocity = new Vector2(-currentSpeed, ridgiBody.velocity.y);
            }
        }

	if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
	animator.SetBool("isMoving",false);
        }
    }





    /*This method makes the character jump multiplying the jump force at vector Y, and the way that the force is applied,
     * in this case is impulse
     */

    void Jump(bool superJump)
    {
	   
	//If the character is touching the ground, the character jumps
        if (IsTouchingTheGround())
        {
		GetComponent<AudioSource>().PlayOneShot(this.jumpSound);
		//If the manaPoints are same o more than 5 and super jum is called, the character will super jum
            if(this.manaPoints>=COST_SUPERJUMP && superJump==true){
	    
	    
            ridgiBody.AddForce(Vector2.up * jumpForce *FORCE_SUPERJUMP, ForceMode2D.Impulse);
	    this.manaPoints-=COST_SUPERJUMP;
		

	    //the character does a normal jump
	    }else{

	    ridgiBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

	    
	    }
	    }

	        
    }





    //Return true, if the character is touching the ground
    bool IsTouchingTheGround()
    {
        /**
         * From the character's position, throw a Raycast to down, and check if the character is touching
         * the ground until 30cm
         */
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.3f, groundLayer)){
            
            
            return true;
        }
        else
        {
           
            return false;
        }
    }

    //This method kill the player
    public void kill()
    {
        //Change the gameState at game manager
        GameManager.sharedInstance.GameOver();

        //change to the kill animation
        this.animator.SetBool("isAlive", false);

    	//get the current maximum distance
	float  currentMaxDistance=PlayerPrefs.GetFloat("maxDistance",0);

	//If the current maximum distance is less than the current distance, set a new record distance	
	if(currentMaxDistance<this.GetDistance()){
	
		PlayerPrefs.SetFloat("maxDistance",this.GetDistance());
	
	}
    
    }

    	//get the current distance
	public float GetDistance(){
	
	float travelledDistance= Vector2.Distance(new Vector2(initialPosition.x,0), new Vector2(this.transform.position.x,0));

	
	return travelledDistance;
	}

	//This method is called when the character collects a health potion
	public void CollectHealth(int points){
	
		this.healthPoints+=points;
		if(this.healthPoints<=(int)MAX_HEALTH){
		this.healthPoints=(int)MAX_HEALTH;
		}
		
	
	}

	//this method is called when the character collects a mana potion
	public void CollectMana(int points){
	
		this.manaPoints+=points;

		if(manaPoints>=(int)MAX_MANA){
	manaPoints=(int)MAX_MANA; 
	
	}
}

	public int GetHealthPoints(){
	
	return this.healthPoints;
	}

	public int GetManaPoints(){
	
	return this.manaPoints;
	}
}

