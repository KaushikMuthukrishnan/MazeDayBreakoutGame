using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    private float TimeStamp;
    public GameObject shotPrefab;
    public Camera cam;
    //name changed cuz it was giving an error
    public GameObject Gun;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

            if (TimeStamp <= Time.time)
            {
                //firerates
                TimeStamp = Time.time + 1.5f;
                Shoot();

            }
        }
    }

    void Shoot()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //check if the guns parernt is the called "GunPlaceHolder" to see if the gun is in the players hands 
            if (Gun.transform.parent.gameObject == GameObject.Find("GunPlaceHolder"))
            {

                Debug.Log(hit.point);
                GameObject laser = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation);
                laser.transform.LookAt(hit.point);
                laser.GetComponent<ShotBehavior>().setTarget(hit.point);
                //TODO: Need to fix a bug where the laser goes through the wall. 
                Destroy(laser, 1f);




            }

        }


        //For the lazer, I would check out the Line renderer cuz its much simpler to turn on and off than to instantiate new gameojects
        //it takes a while to get used to tho

        //? uh, I dont know what you mean by turn on and off. I thought we were doing as the same as the star wars blasters where its just a lazer bullet.





    }
}


