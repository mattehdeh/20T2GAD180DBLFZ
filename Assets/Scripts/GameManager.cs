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
                Debug.Log("We're sitting in Menu");
                GameObject.FindGameObjectWithTag("StartButton").GetComponent<ButtonManager>().startEvent += CallStartEvent;
                break;
            case gameStates.start:
                Debug.Log("Game has begun");
                if (GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeRemaining < 0)
                    myState = gameStates.lose;

                //if (player finds object) myState = gameStates.win;
                break;
            case gameStates.win:
                gameOver = true;
                break;
            case gameStates.lose:
                gameOver = true;
                Debug.Log("Game Over");
                break;
        }
    }

    public void CallStartEvent(bool begin)
    {
        startEvent(begin);
        myState = gameStates.start;
    }
}