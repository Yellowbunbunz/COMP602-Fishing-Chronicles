using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public static ItemPickup Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        //Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
