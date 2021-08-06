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
        if (gunEnabled && !Movement.frozen) //checks for if gun is enabled, and if not in UI scene
        {
            Physics.Raycast(ray, out RaycastHit hit);
            GameObject laser = Instantiate(shotPrefab, transform.position, transform.rotation);
            laser.transform.LookAt(hit.point != null ? hit.point : ray.origin);
            laser.GetComponent<ShotBehavior>().setTarget(hit.point != null ? hit.point : ray.origin);
            print(hit.collider);
            hit.collider?.GetComponentInParent<Enemy>()?.TakeDamage(40); // inflicts damage on enemy
            //TODO ADJUST DAMAGE RATE

            //New bug is when the shot is aimed into empty space, the shot goes towards one specific spot
            //Cant figure out how to fix it but we shouldnt worry abt it for now, its very minor, since most of our map will have colliders and 
            //structure so hit.point will almost never be null

            //TODO: Need to fix a bug where the laser goes through the wall. 
            //Destroy(laser, 1f); laser is auto destroyed in source code upon reaching target

        }
    }
}


