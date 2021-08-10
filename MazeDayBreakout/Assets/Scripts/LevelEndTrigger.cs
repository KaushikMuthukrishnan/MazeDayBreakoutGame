using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    public TextMeshProUGUI tooltip;

    private void OnTriggerStay(Collider other)
    {
        if (MailApp.mailSent && other.CompareTag("Player"))
        {
            tooltip.text = "Press SPACE to Escape!";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(2);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (MailApp.mailSent && other.CompareTag("Player"))
            tooltip.text = "";
    }
}
