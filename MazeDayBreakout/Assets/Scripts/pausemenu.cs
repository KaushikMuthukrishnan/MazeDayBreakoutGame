using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Movement.frozen = EmailTrigger.usingEmail;
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = EmailTrigger.usingEmail? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = EmailTrigger.usingEmail;
    }


    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Movement.frozen = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
