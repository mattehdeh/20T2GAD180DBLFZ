using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event System.Action<bool> startEvent;
    public bool gameOver = false;

    public enum gameStates
    {
        menu,
        start,
        win,
        lose
    }

    public gameStates myState;



    //switch
    //change states

    // Start is called before the first frame update
    void Start()
    {
        myState = gameStates.menu;
        Debug.Log("We're sitting in Menu");
    }

    private void Update()
    {
        if (gameOver == false)
        CheckState();
    }

    public void CheckState()
    {
        switch (myState)
        {
            case gameStates.menu:
                //set payer input to false
                break;
            case gameStates.start:
                //set player input to true
                if (GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeRemaining < 0)
                {
                    myState = gameStates.lose;
                    Debug.Log("Game Lose");
                }


                //if (player finds object){ myState = gameStates.win; Debug.Log("Game Win"); }
                break;
            case gameStates.win:
                //set payer input to false
                gameOver = true;
                break;
            case gameStates.lose:
                //set payer input to false
                gameOver = true;

                break;
        }
    }

    public void CallStartEvent()
    {
        startEvent(true);
        myState = gameStates.start;
        Debug.Log("Game has begun");
    }
}