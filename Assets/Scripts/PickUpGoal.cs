using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGoal : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public GameObject guide;
    // public bool itemGot;
    // I commented this and all itemGot references out because I don't need them to trigger the event
    // I also don't need the goal object to be released if the game ends on pickup. If we add something else, we can uncomment these things

    public event System.Action<bool> goalGet;

    void Awake()
    {
        //itemGot = false;
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
        Debug.Log("Goal Is Get");
        //could put a call here for a coroutine in an IEnumerator to trigger the event goalGet after a second or two 
        //this would cause a slight delay between picking the object up and other functions but it would also keep the timer running
        //unless an IEnumerator was added to the subscribers to these events, then it would wait for a sec without the timer continuing to countdown
        goalGet(gotten);
        //itemGot = gotten;

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
        //if (itemGot == false)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            item.transform.position = guide.transform.position;
        }
    }
}
