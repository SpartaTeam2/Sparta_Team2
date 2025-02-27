using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PanelUI : MonoBehaviour
{
    public GameObject losePanel; 
    public GameObject winPanel;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI goldText1;

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
            GameClear(5000);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameOver(500);
        }
    }
    public void GameOver(int stagegold)
    {
        Time.timeScale = 0f; 
        losePanel?.SetActive(true);
        goldText1.text = $"GOLD : {stagegold.ToString()}";
    }
    public void GameClear(int stagegold)
    {
        Time.timeScale = 0f; 
        winPanel?.SetActive(true);
        goldText.text = $"GOLD : {stagegold.ToString()}";
    }
}
