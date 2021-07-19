using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float speed = 5f;
    float runspeed = 10f;
    float height = 500f;
    public bool isGrounded;
    public CharacterController characterController;
    Vector3 velocity;
    public GameObject Player;
    public Animator bobController;

/*    public Transform GroundCheck;
    public float GroudDistance = 0.4f;*/
/*    public LayerMask GroundMask;*/

    void Update()
    {
        isGrounded = characterController.collisionFlags != 0;
        //isGrounded = Physics.CheckSphere(GroundCheck.position, GroudDistance, GroundMask);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        if (isGrounded)
        {
            //Honestly im very much considering removing jump, i spent all day on it lol
            //We can add at end if we have time tbh
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = 0;
                characterController.Move(new Vector3(0, height, 0) * Time.deltaTime);
                isGrounded = false;
            }
            else
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
/*        if (isGrounded && velocity.y < 0)
        {
<<<<<<< Updated upstream
            velocity.y = -2f;
        }*/
            velocity.y += -9.8f * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
=======
            velocity.y = -2f; 
>>>>>>> Stashed changes
        }
    }

}
