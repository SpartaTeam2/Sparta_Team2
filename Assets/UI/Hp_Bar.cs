using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hp_Bar : MonoBehaviour
{
    public PlayerCtrl player;
    public Slider hpbar;
    public float maxHp;
    public float currenthp;
    public Text nowHpText;
    public float damageRate = 0f; 

    void Start()
    {
        player.HP = player.MaxHp;  

        if (hpbar != null)  
        {
            hpbar.value = player.HP; 
        }

       
        UpdateHpText(); 
    }
        
    void Update()
    {
        
        if (hpbar != null)
        {
            hpbar.value = player.HP; 
        }
        TakeDamage(damageRate * Time.deltaTime);

        UpdateHpText();
    }
    public void TakeDamage(float damage)
    {
        player.HP -= damage;
        if (player.HP < 0)
        {
            player.HP = 0;
        }
        UpdateHpText();
    }

    void UpdateHpText()
    {
       
        if (nowHpText != null)
        {
            nowHpText.text = player.HP.ToString("N0"); 
        }
    }
}
