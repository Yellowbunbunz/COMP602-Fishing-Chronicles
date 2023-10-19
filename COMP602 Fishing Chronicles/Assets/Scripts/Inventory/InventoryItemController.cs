using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public static InventoryItemController Instance;
    Item item;

    public Button removeButton;
    public Button sellButton;

    private void Awake()
    {
        Instance = this;

    }

    public void ShowSellButton()
    {
        sellButton.gameObject.SetActive(true);
    }

    public void HideSellButton()
    {
        sellButton.gameObject.SetActive(false);
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void SellItem()
    {
        InventoryManager.Instance.SellItems(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
