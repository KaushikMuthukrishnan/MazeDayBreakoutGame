using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GunManager : MonoBehaviour
{
    public Transform parentOnPick;
    public TextMeshProUGUI tooltip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tooltip.text = "Press F to pick up";
            //@UIPerson, add visual appeal here if needed
            StartCoroutine(PromptGunPick());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tooltip.text = "";
            StopCoroutine(PromptGunPick());

        }
    }

    IEnumerator PromptGunPick()
    {
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.F));
        Transform t;
        if (transform.childCount > 0) //makes sure there is a child so t.getChild doesnt return an error
        {
            t = transform.GetChild(0);
            t.transform.SetPositionAndRotation(parentOnPick.transform.position, parentOnPick.transform.rotation);
            t.SetParent(parentOnPick);
            Destroy(transform.gameObject);
        }
        //This sequence makes the orphan Gun as a child of the Main Camera
        //Also sets the transform and rotation to match the preset object on the Cam
        yield return null;

    }
}
