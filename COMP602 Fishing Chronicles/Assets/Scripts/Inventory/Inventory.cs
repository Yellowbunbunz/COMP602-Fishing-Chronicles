using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region singleton

    public static Inventory Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate{};

    public List<Item> InventoryList = new List<Item>();
    public List<Item> HotBarList = new List<Item>();
    public HotBarControler HotBarControler;

    public void SwitchHotBarInventory(Item item)
    {
        //inventory to hotbar(check if there is space)
        foreach(Item i in  InventoryList)
        {
            if (i == item)
            {
                if (HotBarList.Count >= HotBarControler.HotBarSlotSize)
                {
                    Debug.Log("No more space");
                }
                else 
                {
                    HotBarList.Add(item);
                    InventoryList.Remove(item);
                    onItemChange.Invoke();
                }
                return;
            }
        }

        //hotbar to inventory

        foreach(Item i in HotBarList)
        {
            if(i== item)
            {
                HotBarList.Remove(item);
                InventoryList.Add(item);
                onItemChange.Invoke();
                return;
            }
        }
    }

    public void AddItem(Item item)
    {
        InventoryList.Add(item);
        onItemChange.Invoke();
    }

    public void RemoveItem(Item item) 
    { 
        if(InventoryList.Contains(item))
        {
            InventoryList.Remove(item);
        }
        else if(HotBarList.Contains(item))
        {
            HotBarList.Remove(item);
        }
        
        onItemChange.Invoke();
    }
}
