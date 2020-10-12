using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    
    public static LevelGenerator sharedInstance;                            // singletone variable
    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();     // List of block which we will make a level
    public Transform levelStartPoint;                                       // point where the nivel has to make itself
    public List<LevelBlock> currentBlocks = new List<LevelBlock>();         // List of blocks that are currently in the scene

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        AddLevelBlock();
        AddLevelBlock();
        AddLevelBlock();
        AddLevelBlock();

    }

    //This method add a new block to level
    public void AddLevelBlock()
    {
        //First, We have to choose one block of the list that we have.
        //Random.Range(a,b) generates a random number between a and b.
        int randomIndex = Random.Range(0, allTheLevelBlocks.Count);
        LevelBlock currentBlock = (LevelBlock)Instantiate(allTheLevelBlocks[randomIndex]);

        //Here we have to indicate which is the parent, and the second variable put as false to delete later
        currentBlock.transform.SetParent(this.transform, false);


        //Now we have to indicate the position. So we have to check the current blocks. Create a Vector3 and to get the position
        Vector3 spawnPosition = Vector3.zero;
        if (currentBlocks.Count == 0)
        {
            //Here Vector 3 get the position of the first block
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            //Here Vector 3 get the exit position of the last block created
            spawnPosition = currentBlocks[currentBlocks.Count - 1].exitPoint.position;
        }

        //We have to correct the spawnPosition to create the different blocks in a correct way
        Vector3 correction = new Vector3(spawnPosition.x - currentBlock.startPoint.position.x,
                                       spawnPosition.y - currentBlock.startPoint.position.y,
                                       0);

        //Assign the position to current block
        currentBlock.transform.position = correction;

        //finally add the block in the scene
        currentBlocks.Add(currentBlock);
        
    }

    //This method remove the oldest block in the level
    public void RemoveOldestLevelBlock()
    {

    }

    //This method remove all the blocks inside the level
    public void RemoveAllTheBlocks()
    {

    }

    //This method generates the initial blocks of the level
    public void GenerateInitialBlocks()
    {

    }
}
