using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level_Bar : MonoBehaviour
{
    public PlayerCtrl player;
    public Slider experienceSlider; // ����ġ �����̴�
    public Text levelText; // ���� �ؽ�Ʈ (���� ����)
    public float currentExperience = 0f; // ���� ����ġ
    public float maxExperience = 100f; // �ִ� ����ġ (������ ����)
    public int currentLevel = 1; // ���� ����
    public float experiencePerSecond = 0f; // �ʴ� �����ϴ� ����ġ ��

    void Start()
    {        
        experienceSlider.minValue = 0f;
        experienceSlider.maxValue = player.MaxExp;
        experienceSlider.value = player.Exp;
       
        UpdateLevelText();
    }

    void Update()
    {
        
        AddExperience(player.Exp);
    }

    
    public void AddExperience(float amount)
    {
        player.Exp += amount;

        
        if (player.Exp >= player.MaxExp)
        {
            LevelUp();
        }
        else
        {
            
            experienceSlider.value = player.Exp;
        }
    }

    
    void LevelUp()
    {
        //player.level++;
        //player.Exp -= player.MaxExp;
        //player.MaxExp *= 1.2f; 

        
        experienceSlider.maxValue = player.MaxExp;
        experienceSlider.value = player.Exp;

        if (experienceSlider != null)
        {
            experienceSlider.maxValue = player.MaxExp; // �����̴� �ִ밪 ������Ʈ
        }
        UpdateLevelText();

        Debug.Log("���� ��! ���� ����: " + player.level);
    }

    
    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + player.level;
        }
    }
}
    

