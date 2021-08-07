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
    public static bool gunEnabled = false;

    public AudioSource gunShot;

    private void Start()
    {
        gunShot = GetComponent<AudioSource>();
    }

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
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (gunEnabled && !Movement.frozen && Physics.Raycast(ray, out RaycastHit hit)) //checks for if gun is enabled, and if not in UI scene
        {
            gunShot.Play();
            Debug.Log(hit.point);
            GameObject laser = Instantiate(shotPrefab, transform.position, transform.rotation);
            laser.transform.LookAt(hit.point);
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            //TODO: Need to fix a bug where the laser goes through the wall. 
            Destroy(laser, 1f);

        }
    }
}


