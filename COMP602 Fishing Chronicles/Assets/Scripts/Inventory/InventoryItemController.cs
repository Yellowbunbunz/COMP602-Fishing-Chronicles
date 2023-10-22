using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public static InventoryItemController Instance;
    public InventoryManager inventoryManager;
    Item item;

    public Button removeButton;
    public Button sellButton;

    public static int instanceCount = 0;

    private void Start()
    {
        Button button = sellButton.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

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

    public void SellItem(Item item)
    {

        if (InventoryManager.Instance != null && item != null)
        {
            Debug.Log("Yeah, I'm entering this method now");
            InventoryManager.Instance.SellItems(item);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("InventoryManager or item reference is not set.");
        }
    }

    void TaskOnClick()
    {
        Debug.Log("Yes, button is clicked");
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
