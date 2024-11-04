using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerController : MonoBehaviour
{

    [SerializeField] GameObject PanelWin;
    [SerializeField] GameObject PanelLose;


    private void OnEnable()
    {
        playerController.OnWinPlayer += Win;
        playerController.OnDestroyPlayer += Lose;
    }
    private void OnDisable()
    {
        playerController.OnWinPlayer -= Win;
        playerController.OnDestroyPlayer -= Lose;
    }

    void Win()
    {
        Time.timeScale = 0.0f;
        PanelWin.SetActive(true);
    }

    void Lose()
    {
        Time.timeScale = 0.0f;
        PanelLose.SetActive(true);
    }
}
