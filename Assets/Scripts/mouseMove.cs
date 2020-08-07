using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    public bool inputActive = false;

    public float mouseSensitivity = 100f; //speed of movement
    public Transform playerBody;
    float xRotation = 0f;
    public float clampRotation = 90f ;
    GameObject go;

    // Start is called before the first frame update

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //this removes cursor from viewing screen 

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().startEvent += ActivateInput;


        if (inputActive == true)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  //getlocationofmouse 
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -clampRotation, clampRotation); //lockedat90degrees 


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //rotationmovement 
            playerBody.Rotate(Vector3.up * mouseX);
            GameObject.FindGameObjectWithTag("goal").GetComponent<PickUpGoal>().goalGet += DeActivateInput;
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timerUp += DeActivateInput;
        }
        //setup a ray cast
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (go == null)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    if (hit.transform.tag == "hittable")
                    {
                        go = hit.transform.gameObject;
                        go.GetComponent<PickupNew>().Clicked();
                    }
                    else if (hit.transform.tag == "goal")
                    {
                        go = hit.transform.gameObject;
                        go.GetComponent<PickUpGoal>().Clicked();
                    }
                    /*I won't need this because I mistakenly thought other objects would spawn with the spawner but it is only the paper
                    else if (hit.transform.tag == "notGoal")
                    {
                        go = hit.transform.gameObject;
                        go.GetComponent<PickupDecoy>().Clicked();
                    }
                    */
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && go != null)
        {
            if (go.transform.tag == "hittable")
            {
                go.GetComponent<PickupNew>().Release();
            }
            // I don't need this if the game ends on item pickup
            /*else if (go.transform.tag == "goal")
            {
                go.GetComponent<PickUpGoal>().Release();
            }
            // we don't need this because the spawner doesn't spawn 'decoys'
            else if (go.transform.tag == "notGoal")
            {
                go.GetComponent<PickupDecoy>().Release();
            }
            */
            go = null;
        }
    }

    void ActivateInput(bool active)
    {
        inputActive = active;
    }
    void DeActivateInput(bool inactive)
    {
        inputActive = false;
    }
}
