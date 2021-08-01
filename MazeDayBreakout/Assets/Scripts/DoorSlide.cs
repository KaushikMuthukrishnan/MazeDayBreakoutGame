using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    public GameObject LeftDoor;
    public GameObject RightDoor;

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            LeftDoor.transform.position = new Vector3(transform.position.x + 1f, LeftDoor.transform.position.y, LeftDoor.transform.position.z);
            RightDoor.transform.position = new Vector3(transform.position.x + 1f, RightDoor.transform.position.y, RightDoor.transform.position.z);
        }

    }
}
