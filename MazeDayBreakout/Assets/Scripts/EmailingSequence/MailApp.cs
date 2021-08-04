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
        }
        else
        {
            input.text = "";
            placeholderText.text = "Enter a PROPER email...";
        }
    }
}
