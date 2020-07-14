using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    //this script was used to set up the Start Button logic 
    //it became superfluous when the Game Manager took this event
    public event System.Action<bool> startEvent;

    public void CallStartEvent()
    {
        startEvent(true);
    }
}
