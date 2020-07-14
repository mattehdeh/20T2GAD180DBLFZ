using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    //  this is required so the code can control UI elements
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //  these are used to calculate a percentage of time remaining, I left them all public so other scripts can reference them
    public float startingTime;
    public float timeRemaining;
    public float timePercent;

    //this is set to false at the start of the game so the timer doesn't run until it is set to true
    public bool timerIsRunning = false;

    //this is used later to display the time in the UI
    public Text timeText;

    // Start is called before the first frame update
    private void Start()
    {
        //sets the time remaining as the starting time, so we get to keep starting time as a reference
        timeRemaining = startingTime;

    }

    //  Update is called once per frame
    private void Update()
    {
    //  this subscribes to the Game Manager's Start Event activated by clicking the Start Button, and calls the RunTime function
        GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().startEvent += RunTimer;

        //only runs the timer once the timerIsRunning is set to true
        if (timerIsRunning)
        {
            //as long as the timer hasn't reached 0 the timer will countdown, call the display time function, and calculate a percentage of time passed in game
            if (timeRemaining > 0)
            {
                // we use delta time because
                timeRemaining -= Time.deltaTime;
                //this calls the DisplayTime function, setting it's required variable to equal the float of timeRemaining
                DisplayTime(timeRemaining);
                //this calculates a percentage of timeRemaining out of startingTime, 
                //as this decreases, the UI Manager can reference it to manipulate the loading bar graphic
                timePercent = timeRemaining / startingTime;
                //play audio = tick
            }
            //once the timer reaches 0 this will call an event for GameLose in the Game Manager, stand in Debug.Log
            else
            {
                Debug.Log("Time has run out");
                //time remaining is set to 0 to prevent alterations to the displayed time
                timeRemaining = 0;
                //timeIsRunning set to false to prevent further subtractions
                timerIsRunning = false;
            }
        }
    }

    //this function sets the timerIsRunning bool to true, by referencing the RunTimer bool 
    //which recieves it's true status from the Start Event it is subscribed to in the Update Function
    void RunTimer(bool timerStatus)
    {
        timerIsRunning = timerStatus;
    }

    //this function tells the non-diagetic timer in the In Game UI what to display by using the float timeToDisplay
    //the float is set when the function is called in Update following the if clause checking if the timer is running and not at 0
    void DisplayTime(float timeToDisplay)
    {
        //this ensures that for each second showing on the display, we geta  second of game play, rather than the timer being out slightly
        timeToDisplay += 1;

        //this method of calculating time uses the modulo operation '%', returning the remainder of a division into an appropriate figure ie, seconds as a fraction of 60
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //usin string.Format allows us to place variables inside of a formatted string, in this case taking the form of time display
        // the colons used here aren't related to what is seen in display, they are used to seperate a reference number from the value's format
        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
