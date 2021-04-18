using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFade : MonoBehaviour
{
    public float timeToEnd;

    private void Start()
    {
        Invoke("GoToMenu", timeToEnd);
    }

    private void GoToMenu()
    {
        GameManager.Manager.ExitToMenu();
    }
}
