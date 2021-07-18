using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    //change cameras
    public Camera MainCamera, Cutscene;
    public GameObject Flashlight;

    bool camSwitch = false;
    // Start is called before the first frame update
    void Start()
    {

        MainCamera.gameObject.SetActive(camSwitch);
        Cutscene.gameObject.SetActive(!camSwitch);
        Flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camSwitch = !camSwitch;
            MainCamera.gameObject.SetActive(camSwitch);
            Cutscene.gameObject.SetActive(!camSwitch);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Flashlight.SetActive(true);
        }



    }


}
