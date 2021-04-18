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
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void GameOver()
    {
        isTheGameOver = true;
        gameOverMenu.SetActive(true);
    }
}
