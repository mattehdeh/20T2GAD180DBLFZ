using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    //  this is required so the code can control UI elements
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //  this references the sprite from the heirarchy being used for the load bar - specifically the one we want manipulated later
    public Image LoadBar;

    //  these public game objects reference each of the UI Objects we want to manipulate from the heirarchy
    //  we later render them active or inactive, which makes their children visible or not visible
    public GameObject InGameUI;
    public GameObject TitleScreenUI;
    public GameObject WinUI;
    public GameObject LoseUI;

    //  Start is called before the first frame update
    void Start()
    {
    //  this subscribes to the start event in game manager that is triggered by the start button click
    //  It calls the function "HideUI" which sets the process into action to hide the title screen and show the in game UI
        GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().startEvent += HideUI;
    }

    //  Update is called once per frame
    void Update()
    {
    //  calls the Get Time Function below, this is important to make sure the loading bar image manipulation updates each frame
        GetTime();
        if (GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().currentState == "start")
        {
            GameObject.FindGameObjectWithTag("goal").GetComponent<PickUpGoal>().goalGet += Disable;
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timerUp += Disable;
        }
    }

    //  This function is called in Update (every frame) and controls the loading bar graphic
    void GetTime()
    {
    //  sets the fill amount on the load bar to be equal to the float 'time percent' from the Timer object/script
    //  As the time percentage decreases, so does the fill amount of the empty loading bar image
    //  This reveals the green loading behind it, giving the impression that a loading bar is filling up
        LoadBar.fillAmount = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timePercent;
    }

    //  this function is called in the HideUI function after the title screen has been rendered inactive
    void ShowUI(bool show)
    {
        Debug.Log("Show Title Screen");
    //  this checks to see if the InGameUI Obect exists, and if it does, sets that object's active status to true
    //  it is then rendered and becomes visible
        if (InGameUI != null)
        {
            InGameUI.SetActive(show);
        }
    }

    //  this function is called when the game manager's start event is triggered by the start button click bu a subscription to the event
    public void HideUI(bool hide)
    {
        Debug.Log("Hide Title Screen");
    //  this checks to see if the TitleScreen object exists, and if it does, sets that object's active status to false
    //  it is then no longer rendered and no longer visible
        if (TitleScreenUI != null)
        {
            TitleScreenUI.SetActive(false);
        }
    //  this calls the ShowUI function after the Title Screen has been set to active.false
        ShowUI(hide);
    }

    public void GameWin()
    {
        Debug.Log("Show Win Screen");
        if (WinUI != null)
        {
            WinUI.SetActive(true);
        }
    }

    public void GameLose()
    {
        Debug.Log("Show Lose Screen");
        if (LoseUI != null)
        {

            LoseUI.SetActive(true);
        }
    }

    void Disable(bool gameEnd)
    {
        InGameUI.SetActive(false);
        if (GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().currentState == "win")
        {
            Invoke("GameWin", 1.0f);
        }
        if (GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().currentState == "lose")
        {
            Invoke("GameLose", 1.0f);
        }
    }
}
