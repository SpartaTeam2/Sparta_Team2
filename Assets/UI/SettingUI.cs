using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public Button buttonToClick;
    public GameObject back;
    public GameObject targetGameObject; // Ȱ��ȭ/��Ȱ��ȭ�� ���� ������Ʈ
    private bool isGameObjectActive = false; // ���� ������Ʈ�� ���� Ȱ�� ����
    
    void Start()
    {       
        
        if (targetGameObject == null)
        {
            Debug.LogError("GameObject�� �Ҵ���� �ʾҽ��ϴ�!");
            return;
        }
        if (back == null)
        {
            Debug.LogError("GameObject�� �Ҵ���� �ʾҽ��ϴ�!");
            return;
        }



        // ��ư Ŭ�� �̺�Ʈ�� �Լ� ����
        buttonToClick.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // ���� ������Ʈ�� Ȱ�� ���¸� ���
        back.SetActive(isGameObjectActive);
        targetGameObject.SetActive(!isGameObjectActive);        
        
    }

}
