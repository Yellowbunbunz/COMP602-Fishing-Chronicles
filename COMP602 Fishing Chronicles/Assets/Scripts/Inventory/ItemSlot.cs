using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    private Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
    } 

    public void UseItem() 
    {
        if (item == null) return;
        
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            Inventory.Instance.SwitchHotBarInventory(item);
            Debug.Log("Trying to switch");
        }
        else
        {
            item.Use();
        }
            
        
    }
    public void DestroySlot()
    {
        Destroy(gameObject);
    
    }

    public void OnRemoveButtonClicked()
    {
        if(item != null) 
        {
            Inventory.Instance.RemoveItem(item);
        }
    }


    public void OnCursorEnter()
    {
        if (item == null) return;
        //display info
        GameManager.instance.DisplayItemInfo(item.name, item.GetItemDescription(), transform.position);
    }

    public void OnCursorExit()
    {
        if (item == null) return;
        GameManager.instance.DestroyItemInfo(); 
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
    }
}
