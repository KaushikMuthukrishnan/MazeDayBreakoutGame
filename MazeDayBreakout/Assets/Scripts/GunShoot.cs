using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float shootRate = 0.5f;
    private float TimeStamp;
    public GameObject shotPrefab;
    public Camera camera;
    public GameObject Gun;





    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > TimeStamp)
            {
                ShootRay();
                TimeStamp = Time.time + shootRate;
            }
        }

    }

    void ShootRay()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {


            //check if the guns parernt is the called "GunPlaceHolder" to see if the gun is in the players hands 
            if (Gun.transform.parent.gameObject == GameObject.Find("GunPlaceHolder"))
            {

                GameObject laser = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation);
                laser.transform.LookAt(hit.point);
                laser.GetComponent<ShotBehavior>().setTarget(hit.point);
                //TODO: Need to fix a bug where the laser goes through the wall. 
                //Completely Stole "shotbehavior" from the internet lol
                Destroy(laser, 0.25f);
            }
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.point != null)
                {

                }
            }



        }


        //For the lazer, I would check out the Line renderer cuz its much simpler to turn on and off than to instantiate new gameojects
        //it takes a while to get used to tho

        //?thats true, but I think if we had more time we can try the line renderer. But this works for now.





    }

}


