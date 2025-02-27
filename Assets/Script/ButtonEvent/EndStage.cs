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
        // 버튼이 연결되지 않았을 경우 찾아서 연결
        if (button == null)
        {
            button = GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("Button 컴포넌트를 찾을 수 없습니다!");
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
