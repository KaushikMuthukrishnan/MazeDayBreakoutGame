using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float speed = 5f;
    float runspeed = 10f;
    float height = 500f;
    bool isGrounded;
    public CharacterController characterController;
    Vector3 velocity;
    public GameObject Player;
    public Transform GroundCheck;
    public float GroudDistance = 0.4f;
    public LayerMask GroundMask;
    public Animator camBob;

    void Update()
    {
        isGrounded = characterController.detectCollisions;
        //isGrounded = Physics.CheckSphere(GroundCheck.position, GroudDistance, GroundMask);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = 0;
            characterController.Move(new Vector3(0, height, 0) * Time.deltaTime);
            isGrounded = false;

        }
        else
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? runspeed : 5f;
            Vector3 movement = transform.right * x + transform.forward * y;
            characterController.Move(movement * speed * Time.deltaTime);
        }
/*        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }*/
        velocity.y += -9.8f * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

}
