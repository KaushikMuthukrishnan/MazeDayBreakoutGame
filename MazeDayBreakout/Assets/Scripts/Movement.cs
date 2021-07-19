using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float speed = 25f;
    float height = 500f;
    bool isGrounded;
    public CharacterController characterController;
    Vector3 velocity;
    public GameObject Player;
    public Transform GroundCheck;
    public float GroudDistance = 0.4f;
    public LayerMask GroundMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroudDistance, GroundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            characterController.Move(new Vector3(0, height, 0) * Time.deltaTime);
            isGrounded = false;

        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Jump");
        Vector3 movement = transform.right * x + transform.forward * y;
        characterController.Move(movement * speed * Time.deltaTime);
        velocity.y += -9.8f * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }


}
