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
    
    public void AddItem(Item item)
    {
        InventoryList.Add(item);
        onItemChange.Invoke();
    }

    public void RemoveItem(Item item) 
    { 
        InventoryList.Remove(item);
        onItemChange.Invoke();
    }
}
