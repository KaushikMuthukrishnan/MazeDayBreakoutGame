using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 5f;
    float runspeed = 10f;
    public bool isGrounded;
    public CharacterController characterController;
    public Animator bobController;

    public bool Frozen = true;

    void Update()
    {
        isGrounded = characterController.isGrounded;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        speed = Input.GetKey(KeyCode.LeftShift) ? runspeed : 5f;
        bobController.SetBool("Sprinting", bobController.GetBool("Walking") && Input.GetKey(KeyCode.LeftShift)); //triggers sprinting bob only when walking and holding shift

        //check if two objects are colliding


        if (Frozen == true)
        {
            Vector3 movement = transform.right * x + transform.forward * y;
            movement = movement.normalized;
            //SimpleMove() takes care of gravity versus Move()
            characterController.SimpleMove(speed * /*Time.deltaTime * */ movement);
            //triggers the "bobbing" animation when walking
            bobController.SetBool("Walking", isGrounded && movement.sqrMagnitude > 0); //evaluates to true when on floor && when moving
        }
    }

}
