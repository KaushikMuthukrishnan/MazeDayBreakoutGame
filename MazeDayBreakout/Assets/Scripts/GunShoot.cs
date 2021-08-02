using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float shootRate;
    private float TimeStamp;

    public GameObject shotPrefab;

    float range = 100.0f;
    public Camera camera;





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

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            //generate a new shot
            // GameObject laser = (GameObject)Instantiate(m_shotPrefab, hit.point, Quaternion.identity);
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.transform.LookAt(hit.point);
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);

            Destroy(laser, 2f);
        }


        //For the lazer, I would check out the Line renderer cuz its much simpler to turn on and off than to instantiate new gameojects
        //it takes a while to get used to tho

        //?thats true, but I think if we had more time we can try the line renderer. But this works for now.




    }

}


