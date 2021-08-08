using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

// Ok so it looks like there is a bug where if the player holds down the movement keys the camera will bob in the cutscene. It looks werid.
// When going down stairs the player tends to keep flating in one dirction which is weird. I think we should just hard lock the player to the floor. 
// !we are chainging the start. The user will now punch the lock in a animation insead of the player being in control. 
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
        //!@EVERYONE, 
        //!This if statement is to skip cutscenes, and is only for debugging purposes only 
        //!Please delete this before final production of game
        if (Input.GetKeyDown(KeyCode.C))
        {
            var p = gameObject.GetComponent<PlayableDirector>();
            p.time = p.playableAsset.duration;
        }

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
