using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    public GameObject Future_Door;


    // Update is called once per frame
    void Update()
    {
        //when the player press space animation will start
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Future_Door.GetComponent<Animator>().SetTrigger("Trigger");

            Debug.Log("Slide");

        }





    }

}
