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

    public void AddLevelBlock()
    {

    }

    public void RemoveOlvestLevelBlock()
    {

    }

    public void RemoveAllTheBlocks()
    {

    }

    public void GenerateInitialBlocks()
    {

    }
}
