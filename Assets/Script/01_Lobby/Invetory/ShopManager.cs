using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Item item;  // 상점에서 판매하는 아이템
    public Button buyButton;

    private void Start()
    {
        buyButton.onClick.AddListener(BuyItem);
    }

    void BuyItem()
    {
        GameManager.Instance.AddItemToInventory(item);
    }
}
