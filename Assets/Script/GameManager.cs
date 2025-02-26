using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Item> purchasedItems = new List<Item>(); // 구매한 아이템 목록

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 변경되어도 유지
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
