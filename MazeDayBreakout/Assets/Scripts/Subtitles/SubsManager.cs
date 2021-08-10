using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubsManager : MonoBehaviour
{
    public TextMeshProUGUI subs;
    public InputField nameField;
    private string id;

    public static bool enemiesSpawned = false;
    public static bool firstWaveKilled = false;
    public static bool enteredServerRoom = false;
    public static bool sentMail = false;
    public static bool secondWaveTriggered = false;
    public static bool secondWaveKilled = false;
    private void Start()
    {
        StartCoroutine(Subs());
    }

    IEnumerator Subs()
    {
        //Waking p scene
        subs.text = "Wake up.";
        yield return new WaitForSeconds(2f);
        subs.text = "Wake up!";
        yield return new WaitForSeconds(4f);
        subs.text = "Can you remember your name?";
        //TODO Add nameField appearing logic here
        //TODO Save name to file here

        //change wait condidiotn to something else
        ///yield return new WaitUntil(() => wokenUp);
        id = nameField.text;

        //Explaining the need to exit scene
        yield return new WaitForSeconds(1f);
        subs.text = "Yes, " + id;
        yield return new WaitForSeconds(2f);
        subs.text = "I thought you might have lost your memory";
        yield return new WaitForSeconds(2f);
        subs.text = "Anyway, you have to get out of here " + id;
        yield return new WaitForSeconds(2f);
        subs.text = "See if you can punch open your cell door";

        //First wave of guards enter scene
        yield return new WaitUntil(() => enemiesSpawned);
        subs.text = "Oh no! Guards!";
        yield return new WaitForSeconds(2f);
        subs.text = "Kill them off with that gun!";
        yield return new WaitForSeconds(2f);
        subs.text = "";

        //Telling to go to server room scene
        yield return new WaitUntil(() => firstWaveKilled);
        yield return new WaitForSeconds(2f);
        subs.text = "Nice job, always the sharpshooter you were.";
        yield return new WaitForSeconds(6f);
        subs.text = "You know, while we're here";
        yield return new WaitForSeconds(1f);
        subs.text = "we might as well steal some top secret enemy intel.";
        yield return new WaitForSeconds(2f);
        subs.text = "So why don't you head on over to that server room there";
        yield return new WaitForSeconds(2f);
        subs.text = "and see if you can email yourself anything of value?";
        yield return new WaitForSeconds(2f);
        subs.text = "";

        //After email has been sent scene
        yield return new WaitUntil(() => sentMail);
        yield return new WaitForSeconds(4f);
        subs.text = "Awesome!";
        yield return new WaitForSeconds(1f);
        subs.text = "Lets get you out of this place " + id;
        yield return new WaitForSeconds(2f);
        subs.text = "Leave the server room and go to the exit";
        yield return new WaitForSeconds(2f);
        subs.text = "";

        //On second round of enemies scene
        yield return new WaitUntil(() => secondWaveTriggered);
        subs.text = "Ugh. Of course there are more.";
        yield return new WaitForSeconds(2f);
        subs.text = "";

        //After everyone is killed scene
        yield return new WaitUntil(() => secondWaveKilled);
        subs.text = "Finally!";
        yield return new WaitForSeconds(2f);
        subs.text = "Head to the exit " + id + "!";
        yield return new WaitForSeconds(2f);
        subs.text = "";
    }
}
