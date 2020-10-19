using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewInGame : MonoBehaviour
{
	public Text collectableLabel;	//Label of the collectable objects
	public Text distance;		//Label of the current distance
	public Text recordDistance;	//Label of the record distance
    
	// Update is called once per frame
    void Update()
    {

	//If the state of game is inGame or gameOver, the collected objects will show
       if(GameManager.sharedInstance.currentGameState == GameState.inGame || GameManager.sharedInstance.currentGameState == GameState.gameOver){
       
	       int currentObjects=GameManager.sharedInstance.collectedObjetcs;
		this.collectableLabel.text=currentObjects.ToString();


		//If the state of game is inGame, the current distance and the record distance will show
      if(GameManager.sharedInstance.currentGameState==GameState.inGame){
      	
	      //Get the current distance and show it
	      float travelledDistance=PlayerControlerScript.sharedInstance.GetDistance();
      		this.distance.text="Metros\n"+travelledDistance.ToString("f0");

		//Get the maximum record of distance and show it
		float recordCurrentDistance=PlayerPrefs.GetFloat("maxDistance",0);
		this.recordDistance.text="Record\n" + recordCurrentDistance.ToString("f0");
      } 
       } 

       
    }
}
