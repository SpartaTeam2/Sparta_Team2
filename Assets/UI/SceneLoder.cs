using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoder : MonoBehaviour
{
    public string changeScene; // ��ȯ�� ���� �̸�
    public Button button; // ��ư UI ���

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

        
        button.onClick.AddListener(LoadScene);
    }

    
    void LoadScene()
    {
        SceneManager.LoadScene(changeScene);
        if (changeScene == "01_Lobby")
            AudioManager.Instance.IsMainBGM();
    }
}

