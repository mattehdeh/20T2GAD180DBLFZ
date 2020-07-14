using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //this is linked to the sprite being used for the load bar - specifically the one we want manipulated
    public Image LoadBar;

    public GameObject InGameUI;
    public GameObject TitleScreenUI;

    //  Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().startEvent += HideUI;
    }

        //Update is called once per frame
    void Update()
    {
        //calls the Get Time Function below
        GetTime();
    }

    void GetTime()
    {
        //sets the fill amount on the load bar to be equal to the float 'time percent' from the Timer object/script
        LoadBar.fillAmount = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timePercent;
    }

    void ShowUI(bool show)
    {
        Debug.Log("Show Title Screen");
        if (InGameUI != null)
        {
            InGameUI.SetActive(show);
        }
    }

    public void HideUI(bool hide)
    {
        Debug.Log("Hide Title Screen");
        if (TitleScreenUI != null)
        {
            TitleScreenUI.SetActive(false);
        }
        ShowUI(hide);
    }
}
