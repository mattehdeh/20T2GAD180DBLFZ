using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public bool inputActive = false;

    public CharacterController controller; //acsess charactercontroller
    public float speed = 12f; //movement speed 

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().startEvent += ActivateInput;

        if (inputActive == true)
        {

            float x = Input.GetAxis("Horizontal"); // storing position as varible 
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z; //  creates direction want to move by use of varibles
                                                                        //could use new vector 3(x, of, z); global coordinates moves in same way, we need to move ledt right

            controller.Move(move * speed * Time.deltaTime); //using varible set above 
                                                            // moves takes in vector 3 fotr montion move is function with character controller
        }
    }

    void ActivateInput(bool active)
    {
        inputActive = active;
    }
}
