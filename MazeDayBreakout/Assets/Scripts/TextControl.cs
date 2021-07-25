using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{

    public Text WakeupText;
    public Text SubtitleText;
    public Text HQText;
    public Text BadpeopleText;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Subtitles());
    }
    IEnumerator Subtitles()
    {
        yield return new WaitForSeconds(1);
        WakeupText.text = "Ouch My Head.";
        yield return new WaitForSeconds(2);
        WakeupText.text = "What Happended to me?";
        yield return new WaitForSeconds(3);
        WakeupText.text = "Wait, Where am I?";
        yield return new WaitForSeconds(1);
        WakeupText.text = "";
        yield return new WaitForSeconds(10);
        SubtitleText.text = "Hello Agent, so glad you are wake, Bla bla bla I am bla";
        yield return new WaitForSeconds(2);
        SubtitleText.text = "Hi!";
        yield return new WaitForSeconds(3);
        SubtitleText.text = " TEST 3";
        yield return new WaitForSeconds(1);
        SubtitleText.text = "";
    }



}
