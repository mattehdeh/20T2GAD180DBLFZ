using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGoal : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public GameObject guide;
    public bool itemGot;

    public event System.Action<bool> goalGet;

    void Awake()
    {
        itemGot = false;
        item = GameObject.FindGameObjectWithTag("goal");
        tempParent = GameObject.FindGameObjectWithTag("destination");
        guide = GameObject.FindGameObjectWithTag("destination");
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoalIsGet(bool gotten)
    {
        goalGet(gotten);
        //after the start Event is triggered, we shift the state engine into start phase
        itemGot = gotten;
        Debug.Log("Goal Is Get");
    }


    public void Clicked()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
        GoalIsGet(true);

    }

    public void Release()
    {
        if (itemGot == false)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            item.transform.position = guide.transform.position;
        }
    }
}
