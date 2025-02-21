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
    public float damageRate = 10f; // �ʴ� ������

    void Start()
    {
        currenthp = maxHp;  // ���� ü���� �ִ� ü������ �ʱ�ȭ

        if (hpbar != null)  // null üũ �߰�
        {
            hpbar.value = currenthp; // �����̴� �ʱ� �� ����
        }

       
        UpdateHpText(); // �ʱ� �ؽ�Ʈ ������Ʈ
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + new Vector3(0, 0, 0);
        if (hpbar != null)
        {
            hpbar.value = currenthp; // currenthp�� ���� ����
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
            nowHpText.text = currenthp.ToString("N0"); // ���� ü���� ���ڿ��� ��ȯ�Ͽ� ǥ��
        }
    }
}
