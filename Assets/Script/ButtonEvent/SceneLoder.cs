using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoder : MonoBehaviour
{
    public string changeScene; // 전환할 씬의 이름
    public Button button; // 버튼 UI 요소

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

        
        button.onClick.AddListener(LoadScene);
    }

    
    void LoadScene()
    {
        SceneManager.LoadScene(changeScene);
        if (changeScene == "01_Lobby")
            AudioManager.Instance.IsMainBGM();
    }
}

