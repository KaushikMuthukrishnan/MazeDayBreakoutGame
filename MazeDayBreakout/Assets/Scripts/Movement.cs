using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Movement : MonoBehaviour
{
    float speed = 5f;
    float runspeed = 10f;
    public bool isGrounded;
    public CharacterController characterController;
    public Animator bobController;

    bool onoff = false;
    public static bool frozen = false;

    void Update()
    {
        isGrounded = characterController.isGrounded;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        speed = Input.GetKey(KeyCode.LeftShift) ? runspeed : 5f;
        bobController.SetBool("Sprinting", bobController.GetBool("Walking") && Input.GetKey(KeyCode.LeftShift)); //triggers sprinting bob only when walking and holding shift
        if (!Movement.frozen)
        {
            Vector3 movement = transform.right * x + transform.forward * y;
            movement = movement.normalized;

            //SimpleMove() takes care of gravity versus Move()
            characterController.SimpleMove(speed * movement);

            //triggers the "bobbing" animation when walking
            bobController.SetBool("Walking", isGrounded && movement.sqrMagnitude > 0); //evaluates to true when on floor && when moving

            
        }
    }
}
