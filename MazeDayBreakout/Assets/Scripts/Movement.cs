using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float speed = 100f;
    bool isgrounded = false;
    public CharacterController characterController;
    Vector3 velocity;
    GameObject Player;
    Camera cam1;

    Camera cam2;
    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isgrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterController.Move(new Vector3(0, 1, 0) * speed * Time.deltaTime);
            }
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
