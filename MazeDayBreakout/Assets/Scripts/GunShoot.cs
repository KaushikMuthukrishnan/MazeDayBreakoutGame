using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;

    RaycastHit hit;
    float range = 1000.0f;


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }

    }

    void shootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, range))
        {
            //generagte a new shot
            GameObject laser = (GameObject)Instantiate(m_shotPrefab, hit.point, Quaternion.identity);
            laser.GetComponent<Rigidbody>().AddForce(ray.direction * 100.0f);
            // GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            // laser.GetComponent<ShotBehavior>().setTarget(hit.point);

            GameObject.Destroy(laser, 2f);


        }

    }


}
