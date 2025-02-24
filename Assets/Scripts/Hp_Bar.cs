using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hp_Bar : MonoBehaviour
{
    public Transform player;
    public Slider hpbar;
    public float maxHp;
    public float currenthp;
    public Text nowHpText;
    public float damageRate = 10f; 

    void Start()
    {
        currenthp = maxHp;  

        if (hpbar != null)  
        {
            hpbar.value = currenthp; 
        }

       
        UpdateHpText(); 
    }
        
    void Update()
    {
        
        if (hpbar != null)
        {
            hpbar.value = currenthp; 
        }
        TakeDamage(damageRate * Time.deltaTime);

        UpdateHpText();
    }
    public void TakeDamage(float damage)
    {
        currenthp -= damage;
        if (currenthp < 0)
        {
            currenthp = 0;
        }
        UpdateHpText();
    }

    void UpdateHpText()
    {
       
        if (nowHpText != null)
        {
            nowHpText.text = currenthp.ToString("N0"); 
        }
    }
}
