using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveZone : MonoBehaviour
{

    float timeSinceLastDestruction = 0.0f;

    //when the player collides with this collider add a new level block, remove the last one and reset the time since the last destruction
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timeSinceLastDestruction >= 6.0f)
        {
            LevelGenerator.sharedInstance.AddLevelBlock();
            LevelGenerator.sharedInstance.RemoveOldestLevelBlock();
            timeSinceLastDestruction = 0.0f;
        }
    }

    private void Update()
    {
        timeSinceLastDestruction += Time.deltaTime;


    }
}
