using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{

    public Text WakeupText;
    public Text SubtitleText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wakeup());
    }
    IEnumerator wakeup()
    {
        yield return new WaitForSeconds(1);
        WakeupText.text = "Ouch My Head.";
        yield return new WaitForSeconds(2);
        WakeupText.text = "What Happended to me?";
        yield return new WaitForSeconds(3);
        WakeupText.text = "Wait, Where am I?";
        yield return new WaitForSeconds(1);
        WakeupText.text = "";
    }



}
