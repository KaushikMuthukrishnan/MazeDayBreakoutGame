using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wakeup : MonoBehaviour
{
    public Camera MainCamera, Cutscene;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        // Player.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {

            Player.SetActive(true);
            MainCamera.enabled = true;
            Cutscene.enabled = false;

        }
    }

}
