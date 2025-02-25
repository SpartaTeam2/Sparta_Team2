using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelUI : MonoBehaviour
{
    public GameObject losePanel; 
    public GameObject winPanel;

    void Start()
    {
        Time.timeScale = 1f;
        losePanel?.SetActive(false);
        winPanel?.SetActive(false);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            GameClear();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f; 
        losePanel?.SetActive(true); 

    }
    public void GameClear()
    {
        Time.timeScale = 0f; 
        winPanel?.SetActive(true); 
    }
}
