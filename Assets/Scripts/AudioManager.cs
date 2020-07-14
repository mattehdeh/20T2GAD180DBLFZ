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
        GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().startEvent += InGameMusic;
    }
    
    public void InGameMusic(bool listen)
    {
        //play menu music off
        //play in game music on
    }

    public void ButtonClick()
    {
        //play button click
    }

}
