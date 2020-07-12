using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //this is linked to the sprite being used for the load bar - specifically the one we want manipulated
    public Image LoadBar;

    //this is a private game object that will be used by this script to call a variable from the actual Timer
    private GameObject timerObj;

     
   //  Start is called before the first frame update
    void Start()
    {
        //this sets the private game object to the Object in scene with tag "Timer" : that is, our timer.
        timerObj = GameObject.FindGameObjectWithTag("Timer");
    }

  //   Update is called once per frame
    void Update()
    {
        //calls the Get Time Function below
        GetTime();
    }

    void GetTime()
    {
        //sets the fill amount on the load bar to be equal to the float 'time percent' from the Timer object/script
        LoadBar.fillAmount = timerObj.GetComponent<Timer>().timePercent; 
    }
}
