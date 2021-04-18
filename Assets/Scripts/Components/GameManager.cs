using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON FOR GAMEMANAGER
    private static GameManager _instance;
    public static GameManager Manager { get { return _instance; } }
    #endregion

    public GameObject gameOverMenu;
    public bool isTheGameOver = false;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameOver();
        }*/
    }

    public void GameOver()
    {
        isTheGameOver = true;
        gameOverMenu.SetActive(true); //Mostrar el popup de GameOver
        Time.timeScale = 0.0f;
    }

    public void RetryLevel()
    {
        Time.timeScale = 1.0f;
        isTheGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Recargar la escena
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1.0f;
        isTheGameOver = false;
        SceneManager.LoadScene("Menu"); //Recargar la escena
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
