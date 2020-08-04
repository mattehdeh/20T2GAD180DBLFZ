using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //this event is triggered by a function that is called when the Start Game Button is clicked
    //other scripts are subscribed to updates about this event, and rely on it to call essential native functions
    public event System.Action<bool> startEvent;

    //this bool is only set to true when either game win or lose is triggered
    //it is used to prevent further calculations when the game is over
    public bool gameOver = false;

    //this enum sets up the names of our game state types for our game state engine to use
    public enum gameStates
    {
        menu,
        tutorial,
        start,
        win,
        lose
    }

    //this is used to store the current type of game state in our state manager
    public gameStates myState;

    // Start is called before the first frame update
    void Start()
    {
        //this sets the initial game state to be menu
        myState = gameStates.menu;
        Debug.Log("We're sitting in Menu");
    }

    //  Update is called once per frame
    private void Update()
    {
        //as long as the game hasn't finished, the CHeck UPdate function is called every Update
        if (gameOver == false)
        CheckState();
    }

    //this is our game state engine
    //we use this to define what behaviours we need in each game state
    //other scripts can reference this, or we can call events in each state
    public void CheckState()
    {
        //this keeps track of what's in our defined enum type 
        //for each case a different behaviour is defined which might change states depending on events
        //we could also trigger other scripts from inside the state engine from this
        switch (myState)
        {
            //when our game is in it's Menu state, we don't want the player input to be active
            case gameStates.menu:
                //locks the cursor to the game window
                Cursor.lockState = CursorLockMode.Confined;
                //set player input to false
                //we have temporarily done this with an if statement in the player controller script's
                //we also want to ensure the player can still click the start game button
                //so keep an eye out for any bugs that arise from trying to set player input as false in this case
                break;
                //When our game is in it's Tutorial State, the only thing we need is to activate player controller
            case gameStates.tutorial:
                break;
            //when our game is in it's start state we want it to be waiting for the timer to end or for the player to find the goal
            //we also want our player controller to be active here, and we ould trigger the random spawn from in here too
            //at the moment we have those scripts relying on the Start Button Event to activate
            case gameStates.start:
                //set player input to true
                Cursor.visible = false;
                //We find the game object tagged timer and get the timeRemaining float from it's Timer script
                //When the timer is less than Zero, the engine moves into it's Lose state
                if (GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeRemaining < 0)
                {
                    myState = gameStates.lose;
                    Debug.Log("Game Lose");
                }

                //This pending if statement will trigger when the player finds the goal object and the engine will move to win state
                //if (player finds object){ myState = gameStates.win; Debug.Log("Game Win"); }
                break;
            case gameStates.win:
                //pending codes here for what happens if the player wins
                //set payer input to false and bring the cursor back
                Cursor.visible = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().inputActive = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mouseMove>().inputActive = false;
                gameOver = true;
                break;
            case gameStates.lose:
                //pending codes here for what appens if the player loses
                //set payer input to false and bring the cursor back
                Cursor.visible = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().inputActive = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<mouseMove>().inputActive = false;
                gameOver = true;
                break;
        }
    }

    //this is the function that is called when the Start Button is clicked
    //it calls the event and sets it's bool to true, which is carried over into each script subscribed to this event
    public void CallStartEvent()
    {
        startEvent(true);
        //after the start Event is triggered, we shift the state engine into start phase
        myState = gameStates.start;
        Debug.Log("Game has begun");
    }
}