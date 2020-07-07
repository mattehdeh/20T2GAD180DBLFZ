using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextTester : MonoBehaviour
{
    public Text counterText;

    public float seconds, minutes;

    //use this for initialisation
    void Start()
    {
        counterText = GetComponent<Text>() as Text;
    }

    void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
