using System.Collections;
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
    bool onoff = false;
    public GameObject Flashlight;
    public static bool Frozen = false;

    void Update()
    {
        /*        if (Input.GetKey(KeyCode.F) && Pistol != null)
                {
                    Pistol.SetActive(false);
                    Gun.SetActive(true);
                    Pistol = null;
                    StartCoroutine(Tooltips());
                    Flashlight.SetActive(onoff);
                }*/
        /*        if (Input.GetKeyDown(KeyCode.F))
                {
                    onoff = !onoff;
                    Flashlight.SetActive(onoff);
                }*/


        //@ARTHUR
        //Flashlight will be moved to GunManager.cs if the feature is needed
        isGrounded = characterController.isGrounded;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        speed = Input.GetKey(KeyCode.LeftShift) ? runspeed : 5f;
        bobController.SetBool("Sprinting", bobController.GetBool("Walking") && Input.GetKey(KeyCode.LeftShift)); //triggers sprinting bob only when walking and holding shift

        if (!Movement.Frozen)
        {
            Vector3 movement = transform.right * x + transform.forward * y;
            movement = movement.normalized;

            //SimpleMove() takes care of gravity versus Move()
            characterController.SimpleMove(speed * movement);

            //triggers the "bobbing" animation when walking
            bobController.SetBool("Walking", isGrounded && movement.sqrMagnitude > 0); //evaluates to true when on floor && when moving
        }
    }







    /*    void OnTriggerEnter(Collider other)
        {
            Movement.Frozen = false;


    *//*        if (other.tag == "Guns")
            {
                tooltips.text = "Press 'F' to pick up the gun";
                Pistol = other.gameObject;
            }*//*


        }
        private void OnTriggerExit(Collider other)
        {
    *//*        if (other.tag == "Guns")
            {
                tooltips.text = " ";
                Pistol = null;
            }*//*
        }

    *//*    IEnumerator Tooltips()
        {
            yield return new WaitForSeconds(1);
            tooltips.text = "Press F: Built in Flashlight \n Press R:Reaload Mag";
            //tooltips.text = tooltips.text.Replace("\\n", "\n");
            yield return new WaitForSeconds(5);
            tooltips.text = "";

        }*/

}
