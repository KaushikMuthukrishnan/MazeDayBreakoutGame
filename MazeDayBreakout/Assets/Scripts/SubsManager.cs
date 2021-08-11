using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubsManager : MonoBehaviour
{
    public TextMeshProUGUI subs;
    public InputField nameField;
    public GameObject waveOne, waveTwo;
  
    
    private string id;

    public static bool nameEntered = false;
    public static bool firstWaveTriggered = false;
    public static bool firstWaveKilled = false;
    public static bool enteredServerRoom = false;
    public static bool sentMail = false;
    public static bool secondWaveTriggered = false;
    public static bool secondWaveKilled = false;
    private void Start()
    {
        GameObject.Find("Keyboard").GetComponent<Target>().enabled = false;
        GameObject.Find("Gun").GetComponent<Target>().enabled = false;
        GameObject.Find("Future_Door_Final").GetComponent<Target>().enabled = false;
        GameObject.Find("Future_Door_Final (2)").GetComponent<Target>().enabled = false;
        StartCoroutine(Subs());
    }

    private void Update()
    {
        firstWaveKilled = waveOne.transform.childCount == 0;
        secondWaveKilled = waveTwo.transform.childCount == 0;
    }

    IEnumerator Subs()
    {
        //Waking p scene
        yield return new WaitForSeconds(1f);
        subs.text = "Wake up.";
        yield return new WaitForSeconds(2f);
        subs.text = "";
        yield return new WaitForSeconds(2f);
        subs.text = "Wake up!";
        yield return new WaitForSeconds(6f);
        subs.text = "Can you remember your name?";


        nameField.gameObject.SetActive(true);
        nameField.Select();
        Movement.frozen = true;

        //TODO Bug with nameField
        yield return new WaitUntil(() => nameEntered);

        id = nameField.text;
        GameObject.Find("InputTextManager").GetComponent<WriteFile>().StoreData(id);

        Destroy(nameField.gameObject);
        Movement.frozen = false;

        //Explaining the need to exit scene
        yield return new WaitForSeconds(1f);
        subs.text = "Yes. " + id + ".";
        yield return new WaitForSeconds(2f);
        subs.text = "I thought you might have lost your memory";
        yield return new WaitForSeconds(2f);
        subs.text = "";
        yield return new WaitForSeconds(2f);
        subs.text = "Anyway, you have to get out of here " + id;
        yield return new WaitForSeconds(2f);
        subs.text = "See if you can punch open your cell door";
        GameObject.Find("Future_Door_Final").GetComponent<Target>().enabled = true;
        yield return new WaitForSeconds(2f);
        subs.text = "";
        //First wave of guards enter scene
        yield return new WaitUntil(() => firstWaveTriggered);
         GameObject.Find("Future_Door_Final").GetComponent<Target>().enabled = false;
        yield return new WaitForSeconds(1f);
        subs.text = "Oh no! Guards!";
        yield return new WaitForSeconds(1f);
        subs.text = "QUCK! Kill them off with that gun!";
       GameObject.Find("Gun").GetComponent<Target>().enabled = true;
        yield return new WaitForSeconds(2f);
        subs.text = "";
        

        //Telling to go to server room scene
        while (waveOne.transform.childCount > 0) //checks to see if there are more than 0 enemies alive
            yield return null;
        yield return new WaitForSeconds(2f);
        subs.text = "Nice job, I always knew that you were a sharpshooter";
        yield return new WaitForSeconds(5f);
        subs.text = "";
        yield return new WaitForSeconds(2f);
        subs.text = "Hold on, while we're here";
        yield return new WaitForSeconds(1f);
        subs.text = "we might as well steal some top secret enemy intel.";
        yield return new WaitForSeconds(2f);
        subs.text = "";
        yield return new WaitForSeconds(2f);
        subs.text = "So why don't you head on over to that server room there";
        yield return new WaitForSeconds(2f);
        subs.text = "and see if you can email yourself anything of value?";
          GameObject.Find("Keyboard").GetComponent<Target>().enabled = true;
        yield return new WaitForSeconds(2f);
        subs.text = "";

        //After email has been sent scene
        yield return new WaitUntil(() => MailApp.mailSent);
          GameObject.Find("Keyboard").GetComponent<Target>().enabled = false;
        yield return new WaitForSeconds(4f);
        subs.text = "Awesome!";
        yield return new WaitForSeconds(1f);
        subs.text = "Now let's get you out of this place " + id;
        yield return new WaitForSeconds(2f);
        subs.text = "";
        yield return new WaitForSeconds(2f);
        subs.text = "Leave the server room and go to the exit";
        GameObject.Find("Future_Door_Final (2)").GetComponent<Target>().enabled = true;
        yield return new WaitForSeconds(3f);
        subs.text = "";

        //On second round of enemies scene
        yield return new WaitUntil(() => secondWaveTriggered);
        subs.text = "Ugh. Of course there are more.";
        yield return new WaitForSeconds(2f);
        subs.text = "";
        //After everyone is killed scene
        while (waveTwo.transform.childCount > 0)
            yield return null;
        yield return new WaitForSeconds(2f);
        subs.text = "Finally!";
        yield return new WaitForSeconds(2f);
        subs.text = "Head to the exit " + id + "!";
        yield return new WaitForSeconds(2f);
        subs.text = "";
    }

    public void SetNameEnter()
    {
        nameEntered = true;
    }
}
