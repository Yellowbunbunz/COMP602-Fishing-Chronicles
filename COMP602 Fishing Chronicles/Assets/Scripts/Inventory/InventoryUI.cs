using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private bool inventoryOpen = false;

    public bool InventoryOpen => inventoryOpen;
    public GameObject InventoryParent;

    private List<ItemSlot> ItemSlotList = new List<ItemSlot>();
    public GameObject ItemSlotPrefab;
    public Transform inventoryItemTransform;

    private void Start()
    {
        Inventory.Instance.onItemChange += UpDateInventoryUI;
        UpDateInventoryUI();
    }

    // Update is called once per frame
    void Update()
    {
        //open and close invenotry
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            if(inventoryOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
      
    }

    private void UpDateInventoryUI()
    {
        int currentItems = Inventory.Instance.InventoryList.Count;
        if(currentItems > ItemSlotList.Count)
        {
            //add more slots
            AddItemSlots(currentItems);
        }
        for (int i = 0; i < ItemSlotList.Count; i++)
        {
            //update the current item
            if (i < currentItems)
            {
                ItemSlotList[i].AddItem(Inventory.Instance.InventoryList[i]);
            }
            else
            {
                ItemSlotList[i].DestroySlot();
                ItemSlotList.RemoveAt(i);
            }
        }
    }

    private void AddItemSlots(int currentItems)
    {
        int amount = currentItems - ItemSlotList.Count;

        for(int i = 0; i < amount; i++)
        {
            GameObject GO = Instantiate(ItemSlotPrefab, inventoryItemTransform);
            ItemSlot newSlot = GO.GetComponent<ItemSlot>();
            ItemSlotList.Add(newSlot);
        }
    }

    //set inventory open to true
    private void OpenInventory()
    {
        ChangeCursorState(false);
        inventoryOpen = true;
        InventoryParent.SetActive(true);
    }

    //set inventory open to false
    private void CloseInventory()
    {
        ChangeCursorState(true);
        inventoryOpen = false;
        InventoryParent.SetActive(false);
 
    }

    private void ChangeCursorState(bool lockCursor)
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
