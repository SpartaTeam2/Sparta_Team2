using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPbar : MonoBehaviour
{
    private BaseEnemy owner;
    private Slider hpbar;
    [SerializeField] private TextMeshProUGUI hpTEXT;

    public void InitHPbar(BaseEnemy owner)
    {
        this.owner = owner;

        hpbar = GetComponentInChildren<Slider>();

        if (hpTEXT == null)
            hpTEXT = GetComponentInChildren<TextMeshProUGUI>();

        UpdateHPBar();
    }

    public void UpdateHPBar()
    {
        int maxHP = owner.MaxHP;
        int currentHP = owner.HP;

        hpbar.value = (float)currentHP / (float)maxHP;

        hpTEXT.text = currentHP.ToString();
    }
}
