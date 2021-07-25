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
        var t = transform.GetChild(0);
        t.transform.position = parentOnPick.transform.position;
        t.transform.rotation = parentOnPick.transform.rotation;
        t.SetParent(parentOnPick);
        Destroy(transform.gameObject);
        yield return null;

    }
}
