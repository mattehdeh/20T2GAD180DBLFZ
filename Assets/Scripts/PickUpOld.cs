using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    
    void OnMouseDown()
    {
        transform.GetComponent<MeshCollider>().enabled = false;
        transform.GetComponent<Rigidbody>().useGravity = false;
        transform.position = theDest.position;
        transform.parent = GameObject.Find("Destination").transform;
    }

    void OnMouseUp()
    {
        transform.parent = null;
        transform.GetComponent<Rigidbody>().useGravity = true;
        transform.GetComponent<MeshCollider>().enabled = true;
    }
}
