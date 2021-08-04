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
        Time.timeScale = 1f;
        //adding the timescale thingies back cuz theres a bug where if u pause while moving, the animation continues
        GameIsPaused = false;

    }


    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Movement.frozen = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
