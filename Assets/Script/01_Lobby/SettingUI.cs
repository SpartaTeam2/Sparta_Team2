using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public Button buttonToClick;
    public GameObject back;
    public GameObject targetGameObject; // 활성화/비활성화할 게임 오브젝트
    private bool isGameObjectActive = false; // 게임 오브젝트의 현재 활성 상태
    
    void Start()
    {       
        
        if (targetGameObject == null)
        {
            Debug.LogError("GameObject가 할당되지 않았습니다!");
            return;
        }
        if (back == null)
        {
            Debug.LogError("GameObject가 할당되지 않았습니다!");
            return;
        }



        // 버튼 클릭 이벤트에 함수 연결
        buttonToClick.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // 게임 오브젝트의 활성 상태를 토글
        back.SetActive(isGameObjectActive);
        targetGameObject.SetActive(!isGameObjectActive);        
        
    }

}
