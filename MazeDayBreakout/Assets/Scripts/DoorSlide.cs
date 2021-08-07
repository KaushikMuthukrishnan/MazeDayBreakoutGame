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

    public AudioSource audio;

    void Start()
    {
        triggerEntered = false;
        neverDone = true;
        

        //get components by name
        text = GameObject.Find("ToolTips").GetComponent<TextMeshProUGUI>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {

        if (neverDone && Input.GetKeyDown(KeyCode.Space) && triggerEntered)
        {
            Future_Door.GetComponent<Animator>().SetTrigger("Trigger");

            audio.Play();

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
            audio.Play();
            Future_Door.GetComponent<Animator>().SetTrigger("Close");
            neverDone = true;
            // Debug.Log("Trigger exited");
        }
        triggerEntered = false;
        text.text = "";
    }


}
