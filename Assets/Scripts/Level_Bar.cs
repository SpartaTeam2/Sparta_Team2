using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level_Bar : MonoBehaviour
{
    public Slider experienceSlider; // ����ġ �����̴�
    public Text levelText; // ���� �ؽ�Ʈ (���� ����)
    public float currentExperience = 0f; // ���� ����ġ
    public float maxExperience = 100f; // �ִ� ����ġ (������ ����)
    public int currentLevel = 1; // ���� ����
    public float experiencePerSecond = 10f; // �ʴ� �����ϴ� ����ġ ��

    void Start()
    {
        
        experienceSlider.minValue = 0f;
        experienceSlider.maxValue = maxExperience;
        experienceSlider.value = currentExperience;
       
        UpdateLevelText();
    }

    void Update()
    {
        
        AddExperience(experiencePerSecond * Time.deltaTime);
    }

    
    public void AddExperience(float amount)
    {
        currentExperience += amount;

        
        if (currentExperience >= maxExperience)
        {
            LevelUp();
        }
        else
        {
            
            experienceSlider.value = currentExperience;
        }
    }

    
    void LevelUp()
    {
        currentLevel++;
        currentExperience -= maxExperience; 
        maxExperience *= 1.2f; 

        
        experienceSlider.maxValue = maxExperience;
        experienceSlider.value = currentExperience;

        
        UpdateLevelText();

        Debug.Log("���� ��! ���� ����: " + currentLevel);
    }

    
    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }
    }
}
    

