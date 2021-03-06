using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


//! Yo, I moved your coliider into the server room desk.


public class EmailTrigger : MonoBehaviour
{
    public TextMeshProUGUI tooltip;
    public CanvasGroup emailPanel, inGamePanel;
    private string originalText;
    public static bool usingEmail;

    private void Awake()
    {
        emailPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        originalText = tooltip.text;
        tooltip.text = "Press F to use Computer";
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            tooltip.text = originalText;
            TurnOnEmail(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        tooltip.text = originalText;
    }

    public void TurnOnEmail(bool yes)
    {
        usingEmail = yes;
        emailPanel.gameObject.SetActive(yes);
        inGamePanel.gameObject.SetActive(!yes); //no
        Movement.frozen = yes;
        Cursor.visible = yes;
        Cursor.lockState = yes ? CursorLockMode.Confined : CursorLockMode.Locked;
    }


}
