using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //play menu music
    }

    // Update is called once per frame
    void Update()
    {
        //when the start event is triggered this will call the InGame Music function below
        GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().startEvent += InGameMusic;
    }
    
    //this function will turn menu music off and in game music on
    public void InGameMusic(bool listen)
    {
        //play menu music off
        //play in game music on
    }

    //this function will be triggered on the start button 
    public void ButtonClick()
    {
        //play button click
    }

}
