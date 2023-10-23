using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MerchantInventoryManager : MonoBehaviour
{
    public static MerchantInventoryManager Instance;
    //public GameObject currencyManagerObject;
    public CurrencyManager currencyManager;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject InventoryUI;

    public bool isInventoryOpen = false;

    public InventoryItemController[] inventoryItems;

    public static int instanceCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
          //  Debug.Log("MerchantInventoryManager Awake");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        instanceCount++;
//        Debug.Log("InventoryManager instance count: " + instanceCount);
    }

    private void Start()
    {
        CloseInventory();

        //currencyManager = currencyManagerObject.GetComponent<CurrencyManager>();
        //if (currencyManager == null)
        //{
        //    Debug.LogError("CurrencyManager script component not found on the CurrencyManager GameObject.");
        //}
    }

    private void Update()
    {
 
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            var sellButton = obj.transform.Find("BuyButton").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }

        SetInventoryItems();
    }

    public void SellItems(Item item)
    {
        if (currencyManager != null)
        {
            currencyManager.AddMoney(item.sellAmount);
            Items.Remove(item);
        }
        else
        {
            Debug.LogWarning("CurrencyManager reference is not set.");
        }
    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        isInventoryOpen = true;
        ListItems();
    }

    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        isInventoryOpen = false;
    }

    public void SetInventoryItems()
    {
        inventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            inventoryItems[i].AddItem(Items[i]);
        }
    }
}
