using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    float speed = 5f;
    float runspeed = 10f;
    public bool isGrounded;
    public CharacterController characterController;
    public Animator bobController;
    public Text tooltips;
    public GameObject Gun;
    public GameObject Pistol = null;
    public bool Frozen = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.F) && Pistol != null)
        {
            Debug.Log("TRIGGERED!");
            Pistol.SetActive(false);
            Gun.SetActive(true);
        }
        isGrounded = characterController.isGrounded;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        speed = Input.GetKey(KeyCode.LeftShift) ? runspeed : 5f;
        bobController.SetBool("Sprinting", bobController.GetBool("Walking") && Input.GetKey(KeyCode.LeftShift)); //triggers sprinting bob only when walking and holding shift
        if (Frozen == false)
        {
            Vector3 movement = transform.right * x + transform.forward * y;
            movement = movement.normalized;
            //SimpleMove() takes care of gravity versus Move()
            characterController.SimpleMove(speed * /*Time.deltaTime * */ movement);
            //triggers the "bobbing" animation when walking
            bobController.SetBool("Walking", isGrounded && movement.sqrMagnitude > 0); //evaluates to true when on floor && when moving
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Frozen = false;

        if (other.tag == "Guns")
        {

            tooltips.text = "Press 'F' to pick up the gun";
            Pistol = other.gameObject;




        }
        // if (other.tag == "Guns" && Input.GetKeyDown(KeyCode.F))
        // {
        //     //your code
        //     Debug.Log("TRIGGERED!");
        //     Pistol.SetActive(false);
        //     Gun.SetActive(true);
        // }

    }



    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Guns")
        {
            tooltips.text = " ";
            Pistol = null;
        }
    }

}
