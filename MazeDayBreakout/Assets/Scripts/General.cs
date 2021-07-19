using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    //change cameras
    public Camera MainCamera, Cutscene;
    public GameObject Flashlight;

    bool onoff = false;
    // Start is called before the first frame update
    void Start()
    {

        MainCamera.enabled = false;
        Cutscene.enabled = true;
        Flashlight.SetActive(onoff);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            MainCamera.enabled = !MainCamera.enabled;
            Cutscene.enabled = !Cutscene.enabled;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            onoff = !onoff;
            Flashlight.SetActive(onoff);

        }



    }


}
