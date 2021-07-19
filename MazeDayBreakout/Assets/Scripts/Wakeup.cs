using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wakeup : MonoBehaviour
{
    public Camera MainCamera, Cutscene;
    public GameObject Player;

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
