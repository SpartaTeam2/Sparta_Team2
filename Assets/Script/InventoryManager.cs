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

        //무기 착용 (한 개만 가능)
        if (itemInfo.itemType == Item.ItemType.Weapon)
        {
            if (weaponSlot.childCount > 0)
            {
                UnequipItem(weaponSlot.GetChild(0).gameObject); // 기존 무기 해제
            }
            item.transform.SetParent(weaponSlot);
        }
        // 방어구 착용 (한 개만 가능)
        else if (itemInfo.itemType == Item.ItemType.Armor)
        {
            if (armorSlot.childCount > 0)
            {
                UnequipItem(armorSlot.GetChild(0).gameObject); // 기존 방어구 해제
            }
            item.transform.SetParent(armorSlot);
        }
        // 장신구 착용 (최대 2개 가능)
        else if (itemInfo.itemType == Item.ItemType.Accessory)
        {
            if (accessorySlot1.childCount == 0)
            {
                item.transform.SetParent(accessorySlot1);

            }
            else if (accessorySlot2.childCount == 0)
            {
                item.transform.SetParent(accessorySlot2);
            }
            else
            {
                return; // 장신구 2개가 모두 차 있으면 착용 불가
            }
        }
        else
        {
            return; // 장비가 아니면 착용 불가
        }

        item.transform.SetAsLastSibling();
        item.GetComponent<Button>().onClick.RemoveAllListeners();
        item.GetComponent<Button>().onClick.AddListener(() => UnequipItem(item));

        // 스탯 반영
        playerAttack += itemInfo.attack;
        playerHp += itemInfo.Hp;
        UpdatePlayerStats();
    }
    public void UnequipItem(GameObject item)
    {
        item.transform.SetParent(inventoryGrid);
        item.transform.SetAsLastSibling();

        item.GetComponent<Button>().onClick.RemoveAllListeners();
        item.GetComponent<Button>().onClick.AddListener(() => EquipItem(item));

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
