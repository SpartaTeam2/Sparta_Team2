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
        DungeonLevelTXT.text = $"던전 레벨: {PlayerPrefs.GetInt("DungeonLevel")}";

        if (!PlayerPrefs.HasKey("DungeonLevel"))
            DungeonLevelTXT.text = "던전 레벨 없음";
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
        if (PlayerPrefs.HasKey("DungeonLevel")) //키값이 있으면
        {
            if (PlayerPrefs.GetInt("DungeonLevel") <= 1) //레벨이 1이하 이면
            {
                PlayerPrefs.SetInt("DungeonLevel", 1); //1로 고정
            }
            else //레벨이 1 초과이면
            {
                PlayerPrefs.SetInt("DungeonLevel", PlayerPrefs.GetInt("DungeonLevel") - 1); //레벨 1 감소
            }
        }
        else //키값이 없으면
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
            Debug.Log("당신 레벨 없잖아 !!");
        }
        ShowDungeonLevel();
        Debug.Log(PlayerPrefs.GetInt("ClearButton Method Ended"));
    }
}
