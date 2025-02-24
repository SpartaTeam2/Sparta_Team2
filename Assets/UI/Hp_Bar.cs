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
    public TextMeshProUGUI nowHpText;
    public float damageRate = 10f; // 초당 데미지

    void Start()
    {
        currenthp = maxHp;  // 현재 체력을 최대 체력으로 초기화

        if (hpbar != null)  // null 체크 추가
        {
            hpbar.value = currenthp; // 슬라이더 초기 값 설정
        }

       
        UpdateHpText(); // 초기 텍스트 업데이트
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + new Vector3(0, 0, 0);
        if (hpbar != null)
        {
            hpbar.value = currenthp; // currenthp를 직접 설정
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
            nowHpText.text = currenthp.ToString("N0"); // 현재 체력을 문자열로 변환하여 표시
        }
    }
}
