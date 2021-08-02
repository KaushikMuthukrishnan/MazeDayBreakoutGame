using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    public GameObject Future_Door;
    public bool neverDone;
    public bool triggerEntered;

    void Start()
    {
        triggerEntered = false;
        neverDone = true;
    }
    void Update()
    {

        if (neverDone && Input.GetKeyDown(KeyCode.Space) && triggerEntered)
        {
            Future_Door.GetComponent<Animator>().SetTrigger("Trigger");

            neverDone = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerEntered = true;
            // Debug.Log("Trigger entered");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (neverDone == false)
        {
            Future_Door.GetComponent<Animator>().SetTrigger("Close");
            neverDone = true;
            // Debug.Log("Trigger exited");
        }
    }


}
