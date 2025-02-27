using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Item> purchasedItems = new List<Item>(); // ������ ������ ���

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� ����Ǿ ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItemToInventory(Item item)
    {
        purchasedItems.Add(item);
    }
}
