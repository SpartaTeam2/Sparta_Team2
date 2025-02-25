using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform inventoryGrid;

    //  무기, 방어구, 장신구 슬롯 구분
    public Transform weaponSlot;        // 무기 슬롯
    public Transform armorSlot;         // 방어구 슬롯
    public Transform accessorySlot1;    // 장신구 슬롯 1
    public Transform accessorySlot2;    // 장신구 슬롯 2


    private GameObject equippedWeapon;
    private GameObject equippedArmor;
    private GameObject equippedAccessory;

    private Dictionary<GameObject, Item> itemData = new Dictionary<GameObject, Item>();
    public TextMeshProUGUI playerStatsText;

    private int playerAttack = 0;
    private int playerHp = 0;

    void Start()
    {
        AddItem(new Item("단검", 10, 2, Resources.Load<Sprite>("Icons/weapon_anime_sword"), Item.ItemType.Weapon));
        AddItem(new Item("심장", 7, 1, Resources.Load<Sprite>("Icons/ui_heart_full"), Item.ItemType.Armor));
        AddItem(new Item("?", 12, 0, Resources.Load<Sprite>("Icons/wogol_idle_anim_f2"), Item.ItemType.Accessory));
        AddItem(new Item("방패", 2, 10, Resources.Load<Sprite>("Icons/wogol_idle_anim_f2"), Item.ItemType.Accessory));
    }

    public void AddItem(Item item)
    {
        GameObject newItem = Instantiate(itemPrefab, inventoryGrid);
        newItem.GetComponentInChildren<Text>().text = item.itemName;
        newItem.GetComponentInChildren<Image>().sprite = item.itemIcon;
        newItem.GetComponent<Button>().onClick.AddListener(() => EquipItem(newItem));

        itemData[newItem] = item;
    }

    public void EquipItem(GameObject item)
    {
        if (!itemData.ContainsKey(item)) return;

        Item itemInfo = itemData[item];

        // 각 슬롯별로 장비할 수 있는 아이템 제한
        switch (itemInfo.itemType)
        {
            case Item.ItemType.Weapon:
                if (equippedWeapon != null) UnequipItem(equippedWeapon);
                equippedWeapon = item;
                item.transform.SetParent(weaponSlot);
                break;

            case Item.ItemType.Armor:
                if (equippedArmor != null) UnequipItem(equippedArmor);
                equippedArmor = item;
                item.transform.SetParent(armorSlot);
                break;
        
               
        }
        

        item.transform.SetAsLastSibling();
        item.GetComponent<Button>().onClick.RemoveAllListeners();
        item.GetComponent<Button>().onClick.AddListener(() => UnequipItem(item));

        playerAttack += itemInfo.attack;
        playerHp += itemInfo.Hp;
        UpdatePlayerStats();
    }

    public void UnequipItem(GameObject item)
    {
        if (!itemData.ContainsKey(item)) return;

        Item itemInfo = itemData[item];

        switch (itemInfo.itemType)
        {
            case Item.ItemType.Weapon: equippedWeapon = null; break;
            case Item.ItemType.Armor: equippedArmor = null; break;
            case Item.ItemType.Accessory: equippedAccessory = null; break;
        }

        item.transform.SetParent(inventoryGrid);
        item.transform.SetAsLastSibling();
        item.GetComponent<Button>().onClick.RemoveAllListeners();
        item.GetComponent<Button>().onClick.AddListener(() => EquipItem(item));

        playerAttack -= itemInfo.attack;
        playerHp -= itemInfo.Hp;
        UpdatePlayerStats();
    }

    void UpdatePlayerStats()
    {
        playerStatsText.text = $"Attack: {playerAttack} | Hp: {playerHp}";
    }
}
