using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Item item;  // �������� �Ǹ��ϴ� ������
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
