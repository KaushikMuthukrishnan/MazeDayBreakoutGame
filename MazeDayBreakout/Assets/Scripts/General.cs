using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    //change cameras
    public Camera MainCamera, Cutscene;
    public GameObject Flashlight;

    bool onoff = false;
    void Start()
    {

        MainCamera.enabled = false;
        Cutscene.enabled = true;
        Flashlight.SetActive(onoff);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            onoff = !onoff;
            Flashlight.SetActive(onoff);
        }

        // THIS IS A DEV SCRIPT! Remove when GAME IS DONE!
        if (Input.GetKeyDown(KeyCode.C))
        {
            MainCamera.enabled = !MainCamera.enabled;
            Cutscene.enabled = !Cutscene.enabled;
        }

        //when the mouse hover is on the gameobject, it will change the color of the gameobject
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        MainCamera.enabled = true;
        Cutscene.enabled = false;
    }
}
