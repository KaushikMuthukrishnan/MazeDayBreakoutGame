using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTENTION:
//This script is not in use in the game
//Switching to the Timeline usage for cutscenes
//Delete if not needed





public class General : MonoBehaviour
{

    //change cameras
    public Camera MainCamera, Cutscene;

    public GameObject Gun;



    void Start()
    {
        Gun.SetActive(false);
        MainCamera.enabled = false;
        Cutscene.enabled = true;


    }

    void Update()
    {


        // THIS IS A DEV SCRIPT! Remove when GAME IS DONE!
        if (Input.GetKeyDown(KeyCode.C))
        {
            MainCamera.enabled = !MainCamera.enabled;
            Cutscene.enabled = !Cutscene.enabled;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        MainCamera.enabled = true;
        Cutscene.enabled = false;
    }
}
