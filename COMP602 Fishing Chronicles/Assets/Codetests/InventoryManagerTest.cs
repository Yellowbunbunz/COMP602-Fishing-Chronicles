using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerTest : MonoBehaviour
{
    // Singleton instance
    public static InventoryManagerTest Instance;

    // List to store items in the inventory
    private List<ItemsTest> inventory = new List<ItemsTest>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Add(ItemsTest item)
    {
        // Add the item to the inventory list
        inventory.Add(item);
    }

    public bool Contains(ItemsTest item)
    {
        // Check if the item is in the inventory list
        return inventory.Contains(item);
    }

    public int GetInventorySize()
    {
        // Get the current size of the inventory
        return inventory.Count;
    }
}

