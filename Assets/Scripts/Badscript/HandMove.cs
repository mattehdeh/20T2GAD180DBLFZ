using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); *5;
        float v = Input.GetAxis("Vertical"); *5;
        

        vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        rb.velocity = vel;


    }
}
