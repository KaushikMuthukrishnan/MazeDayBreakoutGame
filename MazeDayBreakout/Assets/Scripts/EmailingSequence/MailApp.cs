using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MailApp : MonoBehaviour
{
    public GameObject hoverBkgd;
    public GameObject emailApp;
    public TMP_InputField input;
    public TextMeshProUGUI placeholderText;
    public GameObject emailPanel, sentScreen;
    public Button sendButton;


    public void OnHighLight()
    {
        hoverBkgd.SetActive(true);
        //for highlighting the object
    }
    public void OpenMail()
    {
        emailApp.SetActive(true);
    }
    public void OffHighLight()
    {
        hoverBkgd.SetActive(false);
    }

    public void SaveEmail()
    {
        string text = input.text;
        if (text.Contains("@"))
        {
            FindObjectOfType<WriteFile>().StoreData(text);
            input.interactable = false;
            sendButton.interactable = true;
        }
        else
        {
            input.text = "";
            placeholderText.text = "Invalid Email ID...";
        }
    }

    public void SendMail()
    {
        StartCoroutine(SentPage()); 
    }

    private IEnumerator SentPage()
    {
        var img = sentScreen.GetComponent<Image>();
        var color = Color.white;
        color.a = 0;
        img.color = color;
        sentScreen.SetActive(true);
        Destroy(sendButton.gameObject);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            color.a = i;
            img.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);

        var emailManager = GameObject.Find("Email-Interaction");
        emailManager.GetComponent<EmailTrigger>().TurnOnEmail(false);

        Destroy(emailPanel);
        Destroy(emailManager);
        yield break;
    }
}
