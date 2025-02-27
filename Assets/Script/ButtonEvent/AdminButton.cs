using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdminButton : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI DungeonLevelTXT;
    // Start is called before the first frame update
    void Start()
    {
        ShowDungeonLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowDungeonLevel()
    {
        DungeonLevelTXT.text = $"���� ����: {PlayerPrefs.GetInt("DungeonLevel")}";

        if (!PlayerPrefs.HasKey("DungeonLevel"))
            DungeonLevelTXT.text = "���� ���� ����";
    }

    public void UpButton()
    {
        if (PlayerPrefs.HasKey("DungeonLevel"))
        {
            PlayerPrefs.SetInt("DungeonLevel", PlayerPrefs.GetInt("DungeonLevel") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("DungeonLevel", 1);
        }
        ShowDungeonLevel();
        Debug.Log(PlayerPrefs.GetInt("DungeonLevel"));
    }
    public void DownButton()
    {
        if (PlayerPrefs.HasKey("DungeonLevel")) //Ű���� ������
        {
            if (PlayerPrefs.GetInt("DungeonLevel") <= 1) //������ 1���� �̸�
            {
                PlayerPrefs.SetInt("DungeonLevel", 1); //1�� ����
            }
            else //������ 1 �ʰ��̸�
            {
                PlayerPrefs.SetInt("DungeonLevel", PlayerPrefs.GetInt("DungeonLevel") - 1); //���� 1 ����
            }
        }
        else //Ű���� ������
        {
            PlayerPrefs.SetInt("DungeonLevel", 1);
        }
        ShowDungeonLevel();
        Debug.Log(PlayerPrefs.GetInt("DungeonLevel"));
    }
    public void ClearButton()
    {
        if (PlayerPrefs.HasKey("DungeonLevel"))
        {
            PlayerPrefs.DeleteKey("DungeonLevel");
        }
        else
        {
            Debug.Log("��� ���� ���ݾ� !!");
        }
        ShowDungeonLevel();
        Debug.Log(PlayerPrefs.GetInt("ClearButton Method Ended"));
    }
}
