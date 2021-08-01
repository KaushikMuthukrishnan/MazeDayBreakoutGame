using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmailTrigger : MonoBehaviour
{
    public TextMeshProUGUI tooltip;
    public CanvasGroup emailPanel, inGamePanel;  
    private string originalText;

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
            //Instantiate(emailPanel); //keep this if making a prefab for emailcanvas
            emailPanel.gameObject.SetActive(true);
            inGamePanel.gameObject.SetActive(false);
            //TODO replace the setting active with a Activation Track in Timeline
            Movement.frozen = true;

        }



        //TODO DELETE THIS BELOW IF STATEMENT< ONLY FOR TESTING
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Destroy(emailPanel)
            emailPanel.gameObject.SetActive(false);
            inGamePanel.gameObject.SetActive(true);
            //TODO replace the setting active with a Activation Track in Timeline
            Movement.frozen = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        tooltip.text = originalText;
    }
}
