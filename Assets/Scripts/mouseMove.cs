using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    public bool inputActive = false;

    public float mouseSensitivity = 100f; //speed of movement
    public Transform playerBody;
    float xRotation = 0f;

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
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //lockedat90degrees 


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //rotationmovement 
            playerBody.Rotate(Vector3.up * mouseX);

        }
    }

    void ActivateInput(bool active)
    {
        inputActive = active;
    }
}
