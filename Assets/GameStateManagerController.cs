using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerController : MonoBehaviour
{

    [SerializeField] GameObject PanelWin;
    [SerializeField] GameObject PanelLose;


    private void OnEnable()
    {
        playerController.OnDestroyPlayer += Win;
        playerController.OnDestroyPlayer += Lose;
    }
    private void OnDisable()
    {
        playerController.OnDestroyPlayer -= Win;
        playerController.OnDestroyPlayer -= Lose;
    }

    void Win()
    {
        PanelLose.SetActive(true);
    }

    void Lose()
    {
        PanelLose.SetActive(true);
    }
}
