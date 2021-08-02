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

            neverDone = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerEntered = true;
            text.text = "Press Space to Open The Door";
            // Debug.Log("Trigger entered");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (neverDone == false)
        {
            Future_Door.GetComponent<Animator>().SetTrigger("Close");
            neverDone = true;
            text.text = " ";
            // Debug.Log("Trigger exited");
        }
    }


}
