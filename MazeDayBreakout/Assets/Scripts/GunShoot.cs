using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float shootRate = 0.5f;
    private float TimeStamp;
    public GameObject shotPrefab;
    public Camera cam;
    //name changed cuz it was giving an error
    public GameObject Gun;
    public static bool gunEnabled = false;
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

    //AMAAAAZINGGGGGG!!!!
    void ShootRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (gunEnabled && Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject laser = Instantiate(shotPrefab, transform.position, transform.rotation);
            laser.transform.LookAt(hit.point);
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            //TODO: Need to fix a bug where the laser goes through the wall. 
            //Completely Stole "shotbehavior" from the internet lol
            Destroy(laser, 0.25f);
            if (hit.point != null)
            {

            }

        }
    }
}


