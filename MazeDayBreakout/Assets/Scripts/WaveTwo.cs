using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTwo : MonoBehaviour
{
    public GameObject waveTwo;
    private void OnTriggerStay(Collider other)
    {
        if (MailApp.mailSent && Input.GetKeyDown(KeyCode.Space) && other.gameObject.CompareTag("Player"))
        {
            waveTwo.SetActive(true);
            SubsManager.secondWaveTriggered = true;
        }
    }
}
