using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//I think we should move the gun closer to the camera. It feels underwhelming for it to be so small.
public class GunManager : MonoBehaviour
{
    public GameObject oldArms, newArms;
    public TextMeshProUGUI tooltip;
    public GameObject Crosshair;
    private string originalText;
    private void Start()
    {
        Crosshair = GameObject.Find("Crosshair");
        Crosshair.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            originalText = tooltip.text; //placeholder for what was originally here, should be an empty string during actual game
            tooltip.text = "Press F to pick up the weapon";
            //@UIPerson, add visual appeal here if needed
            StartCoroutine(PromptGunPick());

        }
    }
    IEnumerator PromptGunPick()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
        if (transform.childCount > 0) //makes sure there is a child so t.getChild doesnt return an error
        {
            newArms.SetActive(true);
            Destroy(oldArms);
            tooltip.text = originalText;
            Crosshair.SetActive(true);
            GunShoot.gunEnabled = true;
            StopCoroutine(PromptGunPick());
            Destroy(gameObject);
        }
        //This sequence makes the orphan Gun as a child of the Main Camera
        //Also sets the transform and rotation to match the preset object on the Cam
        yield break;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(PromptGunPick());
            tooltip.text = originalText;
        }
    }
}
