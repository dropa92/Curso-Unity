using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerScript : MonoBehaviour{

    public float jumpForce = 5f;    //Jump's force

    private Rigidbody2D ridgiBody;

    public LayerMask groundLayer;   //This variable checks the layer of the ground

    public Animator animator;       //The character's animation
    
    
    
    //Before the game starts, the game have to be configured
    void Awake()
    {
        //We reference our rigidBody with the Rigidbody2D in the Scene 
        ridgiBody = GetComponent<Rigidbody2D>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isAlive", true);
        animator.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {

        //Here, we check if the key Space is down, the character jumps
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Check the character is touching the ground
        animator.SetBool("isGrounded", IsTouchingTheGround());
    }

    /*This method makes the character jump multiplying the jump force at vector Y, and the way that the force is applied,
     * in this case is impulse
     */ 
    void Jump()
    {
        if (IsTouchingTheGround())
        {
            ridgiBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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


}
