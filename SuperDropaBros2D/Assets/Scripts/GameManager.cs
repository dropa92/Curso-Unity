using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//these are the possible states of the game
public enum GameState
{
    menu,
    inGame,
    gameOver
}


public class GameManager : MonoBehaviour
{

    //Variable which refers to GameManager
    public static GameManager sharedInstance;

    /**
     *Variable to know what's the game's state right now
     *at the beginning it will be 'Menu'
     */
    public GameState currentGameState = GameState.menu;



    private void Awake()
    {
        sharedInstance = this;
    }

    private void Update()
    {
        //If the button Start is pressed, the game will continue
        if (Input.GetButtonDown("Start"))
        {
            
            StartGame();
        }

        //If the button Pause is pressed, the game will pause
        if (Input.GetButtonDown("Pause"))
        {
            BackToMenu();
        }
  
    }


    private void Start()
    {
        StartGame();
       
    }




    //This method is responsable to start the game
    void StartGame()
    {
        SetGameState(GameState.inGame);
    }




    //This method is responsable to finish the game when the player dead
    void GameOver()
    {
        SetGameState(GameState.gameOver);
    }



    //this method is responsable to back the menu when the player want
    void BackToMenu()
    {
        SetGameState(GameState.menu);
    }


    //this method is the responsable to change the game's state
    void SetGameState(GameState newGameState)
    {

        if (newGameState == GameState.menu)
        {
            //we have  to prepare the scene to show the menu
        }
        else if (newGameState == GameState.inGame)
        {
            //we have to prepare the scene to play
        }
        else if (newGameState == GameState.gameOver)
        {
            //we have to prepare the scene to finish the game
        }


        //We assign the new state of the game
        this.currentGameState = newGameState;
    }
}
