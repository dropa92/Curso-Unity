﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType{

	healthPotion,
	manaPotion,
	money

}

public class CollectableScript : MonoBehaviour
{

	public CollectableType type=CollectableType.money;
    bool isCollected = false;	
    public int value=0;

    //Method to comprobate which object collisions with this collider
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
	    //If the collider's tag is Player, call the method collect
        if (otherCollider.tag == "Player")
        {
            collect();
        }
        
    }

    //show the components SpriteRenderer and CircleCollider2D
    void show()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
        isCollected = false;
            }

    //hide the components SpriteRenderer and CircleCollider2D
    void hide()
    {
        
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        
    }

    //Collect the object, call the method hide and add the value to variable collectObjects in class GameManager
    void collect()
    {
        isCollected =true;
        hide();
	
	switch(this.type){
	
		case CollectableType.money:
		GameManager.sharedInstance.collectObjects(value);
		break;

		case CollectableType.healthPotion:
		PlayerControlerScript.sharedInstance.CollectHealth(value);
		break;

		case CollectableType.manaPotion:
		PlayerControlerScript.sharedInstance.CollectMana(value);
		break;
	
	}
            }
}
