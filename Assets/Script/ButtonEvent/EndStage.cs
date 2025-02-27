using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndStage : MonoBehaviour
{
    public const string changeScene = "01_Lobby";
    public Button button;

    void Start()
    {
        // ��ư�� ������� �ʾ��� ��� ã�Ƽ� ����
        if (button == null)
        {
            button = GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("Button ������Ʈ�� ã�� �� �����ϴ�!");
                enabled = false;
                return;
            }
        }


        button.onClick.AddListener(EndGame);
    }


    void EndGame()
    {
        StageManager sm = FindObjectOfType<StageManager>();
        PlayerPrefs.SetInt("DungeonLevel", ++sm.DungeonLevel);

        SceneManager.LoadScene(changeScene);
        if (changeScene == "01_Lobby")
            AudioManager.Instance.IsMainBGM();
    }
}
