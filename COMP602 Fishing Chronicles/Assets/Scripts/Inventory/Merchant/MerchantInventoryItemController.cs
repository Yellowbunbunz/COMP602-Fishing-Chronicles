using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantInventoryItemController : MonoBehaviour
{
    public static MerchantInventoryItemController Instance;
    public MerchantInventoryManager merchantInventoryManager;
    Item item;

    public Button removeButton;
    public Button buyButton;

    public static int instanceCount = 0;

    private void Start()
    {
        Button button = buyButton.GetComponent<Button>();
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
        buyButton.gameObject.SetActive(true);
    }

    public void HideSellButton()
    {
        buyButton.gameObject.SetActive(false);
    }

    public void RemoveItem()
    {
        MerchantInventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void SellItem(Item item)
    {

        if (MerchantInventoryManager.Instance != null && item != null)
        {
            Debug.Log("Yeah, I'm entering this method now");
            MerchantInventoryManager.Instance.SellItems(item);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("MerchantInventoryManager or item reference is not set.");
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
