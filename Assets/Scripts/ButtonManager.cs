using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public event System.Action<bool> startEvent;

    public void CallStartEvent()
    {
        startEvent(true);
    }
}
