using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class HotBarControler : MonoBehaviour
{
    public int HotBarSlotSize => gameObject.transform.childCount;
    private List<ItemSlot> hotBarSlots = new List<ItemSlot>();

    KeyCode[] hotBarkeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5};

    private void Start()
    {
        SetUpHotBarSlots();
        Inventory.Instance.onItemChange += UpdateHotBarUI;
    }

    private void Update()
    {
        for(int i = 0;  i < hotBarkeys.Length; i++)
        {
            if (Input.GetKeyDown(hotBarkeys[i]))
            {
                //used item
                hotBarSlots[i].UseItem();
                return;
            }

        }
    }

    private void UpdateHotBarUI()
    {
        int currentUsedSlots = Inventory.Instance.HotBarList.Count;
        for(int i =0; i< HotBarSlotSize; i++)
        {
            if(i<currentUsedSlots)
            {
                hotBarSlots[i].AddItem(Inventory.Instance.HotBarList[i]);
            }
            else
            {
                hotBarSlots[i].ClearSlot();
            }
        }
    }

    private void SetUpHotBarSlots()
    {
        for(int i = 0; i< HotBarSlotSize; i++)
        {
            ItemSlot slot = gameObject.transform.GetChild(i).GetComponent<ItemSlot>();
            hotBarSlots.Add(slot);
        }
    }
}
