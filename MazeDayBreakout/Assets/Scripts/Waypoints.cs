using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waypointimg;
    public Transform target;
    void Start()
    {
        //generate a new waypoint

        waypointimg.transform.position = Camera.main.WorldToScreenPoint(target.position);

    }
    // Update is called once per frame
    void Update()
    {



    }
}
