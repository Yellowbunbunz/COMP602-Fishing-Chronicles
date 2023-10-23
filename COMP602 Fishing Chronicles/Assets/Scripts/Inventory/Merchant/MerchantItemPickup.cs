using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantItemPickup : MonoBehaviour
{
    public Item item;

    public static MerchantItemPickup Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Pickup()
    {
        MerchantInventoryManager.Instance.Add(item);
        //Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
