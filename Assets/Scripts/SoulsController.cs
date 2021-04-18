using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoulsController : MonoBehaviour
{
    public int penachoSoulsGoal;
    public int wrongSoulsLimit;
    public GameObject[] penachoSoulsUI;
    public GameObject[] wrongSoulsUI;

    private int wrongSoulsCounter; //Lleva la cuenta de cuántas almas inocentes se ha llevado el player, si pasa el límite pierde
    private int penachoSoulsCounter; //Lleva la cuenta de cuántas almas coj penacho se ha llevado el player, al llegar al objetivo, gana

    void Start()
    {
        wrongSoulsCounter = 0;
        penachoSoulsCounter = 0;
    }

    void Update()
    {
        if (PassedWrongSoulsLimit())
        {
            GameManager.Manager.GameOver();
        }
        if (MetWinCondition())
        {
            SceneManager.LoadScene("Win");
        }
    }

    private bool MetWinCondition()
    {
        return penachoSoulsCounter == penachoSoulsGoal;
    }

    private bool PassedWrongSoulsLimit()
    {
        return wrongSoulsCounter >= wrongSoulsLimit;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Penacho"))
        {
            penachoSoulsUI[penachoSoulsCounter].SetActive(true);
            penachoSoulsCounter++;
        }
        if (collision.gameObject.CompareTag("Humano"))
        {
            wrongSoulsUI[wrongSoulsCounter].SetActive(true);
            wrongSoulsCounter++;
        }
    }
}
