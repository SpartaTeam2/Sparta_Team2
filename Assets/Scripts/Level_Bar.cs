using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level_Bar : MonoBehaviour
{
    public Slider experienceSlider; // 경험치 슬라이더
    public Text levelText; // 레벨 텍스트 (선택 사항)
    public float currentExperience = 0f; // 현재 경험치
    public float maxExperience = 100f; // 최대 경험치 (레벨업 기준)
    public int currentLevel = 1; // 현재 레벨
    public float experiencePerSecond = 10f; // 초당 증가하는 경험치 양

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

        Debug.Log("레벨 업! 현재 레벨: " + currentLevel);
    }

    
    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }
    }
}
    

