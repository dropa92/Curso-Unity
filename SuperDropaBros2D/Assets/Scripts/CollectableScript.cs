using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    bool isCollected = false;
    public int value=0;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            collect();
        }
        
    }

    void show()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
        isCollected = false;
            }

    void hide()
    {
        
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        
    }

    void collect()
    {
        isCollected =true;
        hide();
        GameManager.sharedInstance.collectObjects(value);
    }
}
