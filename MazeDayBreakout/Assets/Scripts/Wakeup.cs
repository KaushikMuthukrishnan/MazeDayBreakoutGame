using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wakeup : MonoBehaviour
{
    public Camera MainCamera, Cutscene;
    public GameObject Player;
    public CharacterController characterController;
    // bool frozen = true;

    // Start is called before the first frame update
    void Start()
    {
        // Player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /* if (frozen == true)
         {
             characterController.Move(0, 0, 0);
         }*/

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            Player.SetActive(true);
            MainCamera.enabled = true;
            Cutscene.enabled = false;

        }
    }

}
