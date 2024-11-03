using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] Button myButton;
    [SerializeField] GameObject[] arrayObjectives;


    private void Awake()
    {
        myButton = GetComponent<Button>();
    }

    private void Start()
    {
        myButton.onClick.AddListener(Interacture);
    }

    void Interacture()
    {
        for (int i = 0; i < arrayObjectives.Length; i++)
        {
            if (arrayObjectives[i].activeSelf)
            {
                arrayObjectives[i].SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                arrayObjectives[i].SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        
    }
}
