using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{

    public Text text;
    public string textString;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wakeup());
    }
    IEnumerator wakeup()
    {
        yield return new WaitForSeconds(1);
        text.text = "Ouch My Head.";
        yield return new WaitForSeconds(2);
        text.text = "What Happended to me?";
        yield return new WaitForSeconds(3);
        text.text = "Wait, Where am I?";
        yield return new WaitForSeconds(1);
        text.text = "";
    }


}
