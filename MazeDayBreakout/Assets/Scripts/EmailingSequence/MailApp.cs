using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailApp : MonoBehaviour
{
    public GameObject hoverBkgd;
    public GameObject emailApp;

    public void OnHighLight()
    {
        hoverBkgd.SetActive(true);
        //for highlighting the object
    }
    private void OnMouseUpAsButton()
    {
        emailApp.SetActive(true);
    }
    public void OffHighLight()
    {
        hoverBkgd.SetActive(false);
    }
}
