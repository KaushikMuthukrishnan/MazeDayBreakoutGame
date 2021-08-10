using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubsManager : MonoBehaviour
{
    public TextMeshProUGUI subs;
    public InputField nameField;

    public static bool enteredName = false;
    public static bool punchedDoor = false;
    public static bool enemiesSpawned = false;
    public static bool firstWaveKilled = false;
    public static bool enteredServerRoom = false;
    public static bool sentMail = false;
    public static bool secondWaveKilled = false;
    private void Start()
    {
        
    }

    IEnumerator WakeUp()
    {
        subs.text = "Wake up.";
        yield return new WaitForSeconds(2f);
        subs.text = "Wake up!";
        yield return new WaitForSeconds(2f);
        subs.text = "Do you remember your name?";

    }

}
