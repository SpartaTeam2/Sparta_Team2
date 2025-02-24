using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    
        public string itemName;
        public int attack;
        public int Hp;
        public Sprite itemIcon;


    public Item(string name, int atk, int hp, Sprite icon)
        {
            itemName = name;
            attack = atk;
            Hp = hp;
            this.itemIcon = icon;

    }
        

}
