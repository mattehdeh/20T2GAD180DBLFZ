using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDecoy : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public GameObject guide;

    void Awake()
    {
        item = GameObject.FindGameObjectWithTag("notGoal");
        tempParent = GameObject.FindGameObjectWithTag("destination");
        guide = GameObject.FindGameObjectWithTag("destination");
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clicked()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }

    public void Release()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
    }
}