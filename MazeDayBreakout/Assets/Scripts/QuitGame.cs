using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

    public void ExitGame()
    {
        print("Quitting...");
        Application.Quit();
    }
}
