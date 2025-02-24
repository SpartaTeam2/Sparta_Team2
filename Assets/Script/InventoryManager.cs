using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform inventoryGrid;
    public Transform equipGrid;

    private List<GameObject> inventoryItems = new List<GameObject>();
    private List<GameObject> equippedItems = new List<GameObject>();

    public TextMeshProUGUI playerStatsText; // 플레이어 스탯 UI
    private int playerAttack = 0;
    private int playerHp = 0;

    private Dictionary<GameObject, Item> itemData = new Dictionary<GameObject, Item>(); // 아이템 데이터 저장

    void Start()
    {

             AddItem(new Item("단검", 10, 2, Resources.Load<Sprite>("Icons/weapon_anime_sword")));
            AddItem(new Item("심장", 7, 1, Resources.Load<Sprite>("Icons/ui_heart_full")));
            AddItem(new Item("?", 12, 0, Resources.Load<Sprite>("Icons/wogol_idle_anim_f2")));
            AddItem(new Item("방패", 2, 10, Resources.Load<Sprite>("Icons/wogol_idle_anim_f2")));

    }

    public void AddItem(Item item)
    {
        GameObject newItem = Instantiate(itemPrefab, inventoryGrid);

        Text itemText = newItem.GetComponentInChildren<Text>();
        if (itemText != null)
        {
            itemText.text = item.itemName;
        }

        Image itemImage = newItem.GetComponentInChildren<Image>(); 
        if (itemImage != null)
        {
            itemImage.sprite = item.itemIcon; 
        }

        newItem.GetComponent<Button>().onClick.AddListener(() => EquipItem(newItem));
        inventoryItems.Add(newItem);
        itemData[newItem] = item;
    }


    public void EquipItem(GameObject item)
    {
        if (equippedItems.Count >= 4)
            return;

        inventoryItems.Remove(item);
        item.transform.SetParent(equipGrid);
        item.transform.SetAsLastSibling();
        equippedItems.Add(item);

        item.GetComponent<Button>().onClick.RemoveAllListeners();
        item.GetComponent<Button>().onClick.AddListener(() => UnequipItem(item));

        // 스탯 증가
        if (itemData.ContainsKey(item))
        {
            playerAttack += itemData[item].attack;
            playerHp += itemData[item].Hp;
            UpdatePlayerStats();
        }
    }

    public void UnequipItem(GameObject item)
    {
        equippedItems.Remove(item);
        item.transform.SetParent(inventoryGrid);
        item.transform.SetAsLastSibling();
        inventoryItems.Add(item);

        item.GetComponent<Button>().onClick.RemoveAllListeners();
        item.GetComponent<Button>().onClick.AddListener(() => EquipItem(item));

        // ⭐ 스탯 감소
        if (itemData.ContainsKey(item))
        {
            playerAttack -= itemData[item].attack;
            playerHp -= itemData[item].Hp;
            UpdatePlayerStats();
        }
    }

    void UpdatePlayerStats()
    {
        playerStatsText.text = $"Attack: {playerAttack} | Hp: {playerHp}";
    }
}
