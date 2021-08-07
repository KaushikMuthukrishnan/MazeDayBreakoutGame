using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorSlide : MonoBehaviour
{
    public GameObject Future_Door;
    public bool neverDone;
    public bool triggerEntered;
    public TextMeshProUGUI text;

    void Start()
    {
        triggerEntered = false;
        neverDone = true;

        //get components by name
        text = GameObject.Find("ToolTips").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {

        if (neverDone && Input.GetKeyDown(KeyCode.Space) && triggerEntered)
        {
            Future_Door.GetComponent<Animator>().SetTrigger("Trigger");
            text.text = ""; //this is so the tootltip disappears once action is executed;
            neverDone = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerEntered = true;
            text.text = "Press Space To Open Door";
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
        triggerEntered = false;
        text.text = "";
    }


}
