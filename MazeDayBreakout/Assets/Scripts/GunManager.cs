using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//I think we should move the gun closer to the camera. It underwhelming for it to be so small.
public class GunManager : MonoBehaviour
{
    public Transform parentOnPick;
    public TextMeshProUGUI tooltip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tooltip.text = "Press F to pick up the weapon";
            //@UIPerson, add visual appeal here if needed
            StartCoroutine(PromptGunPick());

        }
    }
<<<<<<< refs/remotes/origin/main
    //on trigger exit never runs beacuse the oject is destroyed. So I moved it down.
=======
    //on trigger exit never runs so i moved it down 
>>>>>>> Work In Progress Shooting Script

    IEnumerator PromptGunPick()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
        Transform t;
        if (transform.childCount > 0) //makes sure there is a child so t.getChild doesnt return an error
        {
            t = transform.GetChild(0);
            t.transform.SetPositionAndRotation(parentOnPick.transform.position, parentOnPick.transform.rotation);
            t.SetParent(parentOnPick);
            Destroy(transform.gameObject);
            tooltip.text = " ";
            StopCoroutine(PromptGunPick());
<<<<<<< refs/remotes/origin/main
=======

>>>>>>> Work In Progress Shooting Script
        }


        //This sequence makes the orphan Gun as a child of the Main Camera
        //Also sets the transform and rotation to match the preset object on the Cam
        yield return null;

    }


}
