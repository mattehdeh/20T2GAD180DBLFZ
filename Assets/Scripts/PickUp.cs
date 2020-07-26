using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;
    
    void OnMouseDown()
    {
        //GetComponent<MeshCollider>().enabled = false;
        GetComponent<RigidBody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<RigidBody>().useGravity = true;
        //GetComponent<MeshCollider>().enabled = true;
    }
}
