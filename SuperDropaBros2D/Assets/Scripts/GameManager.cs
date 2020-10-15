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

    public Canvas menuCanvas, canvasGame, canvasGameOver;



    private void Awake()
    {
        sharedInstance = this;
    }

    private void Update()
    {
        //If the button Start is pressed, the game will continue
        if (Input.GetButtonDown("Start") && currentGameState!=GameState.inGame)
        {
           
            StartGame();
           
        }

        //If the button Pause is pressed, the game will pause
        if (Input.GetButtonDown("Pause"))
        {
           
            BackToMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitGame();
        }
  
    }


    private void Start()
    {
        StartGame();
       
    }






    //This method is responsable to start the game
    public void StartGame()
    {
        SetGameState(GameState.inGame);
       

        //get the GameObject MainCamera
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

        //Get the Component CameraFollow
        CameraFollow cameraFollow = camera.GetComponent<CameraFollow>();

        //Call the method ResetCameraPosition()
        cameraFollow.ResetCameraPosition();

        if (PlayerControlerScript.sharedInstance.transform.position.x>80)
        {
            LevelGenerator.sharedInstance.RemoveAllTheBlocks();
            LevelGenerator.sharedInstance.GenerateInitialBlocks();
        }

        PlayerControlerScript.sharedInstance.StartGame();

        
        

    }








    //This method is responsable to finish the game when the player dead
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
       
    }

    public void exitGame()
    {
        Application.Quit();
    }

    //this method is responsable to back the menu when the player want
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
        
    }


    //this method is the responsable to change the game's state
    void SetGameState(GameState newGameState)
    {

        if (newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            canvasGame.enabled=false;
            canvasGameOver.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            canvasGame.enabled= true;
            canvasGameOver.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            canvasGame.enabled= false;
            canvasGameOver.enabled = true;
        }


        //We assign the new state of the game
        this.currentGameState = newGameState;
    }
}
