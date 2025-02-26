using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level_Bar : MonoBehaviour
{
    public PlayerCtrl player;
    public Slider experienceSlider; // 경험치 슬라이더
    public Text levelText; // 레벨 텍스트 (선택 사항)
    public float currentExperience = 0f; // 현재 경험치
    public float maxExperience = 100f; // 최대 경험치 (레벨업 기준)
    public int currentLevel = 1; // 현재 레벨
    public float experiencePerSecond = 0f; // 초당 증가하는 경험치 양

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
            experienceSlider.maxValue = player.MaxExp; // 슬라이더 최대값 업데이트
        }
        UpdateLevelText();

        Debug.Log("레벨 업! 현재 레벨: " + player.level);
    }

    
    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + player.level;
        }
    }
}
    

