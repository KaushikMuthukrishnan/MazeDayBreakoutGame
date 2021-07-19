using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float speed = 5f;
    float runspeed = 10f;

    public bool isGrounded;
    public CharacterController characterController;
    Vector3 velocity;
    public GameObject Player;
    public Animator bobController;


    void Update()
    {
        isGrounded = characterController.collisionFlags != 0;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        if (isGrounded)
        {
            //Honestly im very much considering removing jump, i spent all day on it lol
            //We can add at end if we have time tb1h

            //Agreed, Im removing it.

            {
                speed = Input.GetKey(KeyCode.LeftShift) ? runspeed : 5f;
                bobController.SetBool("Sprinting", isGrounded && Mathf.Abs(y) > 0 && Input.GetKey(KeyCode.LeftShift)); //triggers sprinting bob only when moving forward and on ground

                Vector3 movement = transform.right * x + transform.forward * y;
                characterController.Move(speed * Time.deltaTime * movement);

                //triggers the "bobbing" animation when walking
                bobController.SetBool("Walking", isGrounded && Mathf.Abs(y) > 0); //evaluates to true when on floor && when moving forward

            }
        }
        else
        {

            velocity.y += -9.8f * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);

            // velocity.y = -10f * Time.deltaTime;
        }
    }

}
