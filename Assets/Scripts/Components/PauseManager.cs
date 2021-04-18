using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool isPaused = false;

    private void Update()
    {
        //Solo puede pausar si el juego no está en estado GameOver
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Manager.isTheGameOver)
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                Pause();
            }
        }
    }


    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }
}
