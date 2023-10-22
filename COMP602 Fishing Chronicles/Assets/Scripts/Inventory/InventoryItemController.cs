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

    public static int instanceCount = 0;

    private void Awake()
    {
        Instance = this;

        instanceCount++;
        Debug.Log("Item instance count: " + instanceCount);
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
        if (InventoryManager.Instance != null && item != null)
        {
            InventoryManager.Instance.SellItems(item);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("InventoryManager or item reference is not set.");
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
