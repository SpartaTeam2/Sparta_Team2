using UnityEngine;

public class Item
{
    public enum ItemType { Weapon, Armor, Accessory }

    public string itemName;
    public int attack;
    public int Hp;
    public Sprite itemIcon;
    public ItemType itemType;

    public Item(string name, int atk, int hp, Sprite icon, ItemType type)
    {
        itemName = name;
        attack = atk;
        Hp = hp;
        itemIcon = icon;
        itemType = type;
    }
}
