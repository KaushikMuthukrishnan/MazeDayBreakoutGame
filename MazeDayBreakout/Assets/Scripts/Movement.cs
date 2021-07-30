using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.Playables;

// Ok so it looks like there is a bug where if the player holds down the movement keys the camera will bob even in the cutscene. It looks werid.
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
        //!@EVERYONE, 
        //!This if statement is to skip cutscenes, and is only for debugging purposes only 
        //!Please delete this before final production of game
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject.Find("Main Camera").GetComponent<Controls>().enabled = true;
            var p = gameObject.GetComponent<PlayableDirector>();
            p.time = p.playableAsset.duration;
        }


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
