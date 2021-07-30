using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public float health = 100;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //look at the player
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);


        //move towards the player until we are within a certain distance


    }
}

