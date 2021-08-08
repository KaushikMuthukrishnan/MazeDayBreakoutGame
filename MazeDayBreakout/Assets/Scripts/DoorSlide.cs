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
    private Animator punchAnim;

    void Start()
    {
        triggerEntered = false;
        neverDone = true;

        //get components by name
        text = GameObject.Find("ToolTips").GetComponent<TextMeshProUGUI>();
        punchAnim = GameObject.Find("Main Camera").GetComponentsInChildren<Animator>()[1];
    }
    void Update()
    {

        if (neverDone && triggerEntered && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(OpenDoorAnim());
        }
    }

    IEnumerator OpenDoorAnim()
    {
        text.text = ""; //this is so the tootltip disappears once action is executed;
        punchAnim.Play(GunShoot.gunEnabled ? "PunchLeft" : "PunchRight"); //punches left if gun is held
        yield return new WaitForSeconds(1.5f);
        Future_Door.GetComponent<Animator>().SetTrigger("Trigger");
        neverDone = false;
        yield break;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerEntered = true;
            text.text = "Press SPACE to Punch Open Door";
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
