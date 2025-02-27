using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hp_Bar : MonoBehaviour
{
    public PlayerCtrl player;
    public Slider hpbar;
    public Text nowHpText;
        
    void Update()
    {
        if (hpbar == null)
            return;

        hpbar.value = player.HP / player.MaxHp;
        UpdateHpText();
    }

    void UpdateHpText()
    {
        if (nowHpText == null)
            return;

        nowHpText.text = player.HP.ToString("N0"); 
    }
}
