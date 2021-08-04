using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Movement.frozen = false;
        GameIsPaused = false;

    }


    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Movement.frozen = true;
        GameIsPaused = true;
    }
}
