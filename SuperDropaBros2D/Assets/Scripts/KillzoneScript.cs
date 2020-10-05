using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        //check if the player has collided with the kill zone
        if (other.tag == "Player")
        { 
            //call the kill method at the class of the player
            PlayerControlerScript.sharedInstance.kill();
            Debug.Log("El jugador ha muerto");
        }
    }
}
