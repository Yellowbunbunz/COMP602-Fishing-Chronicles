using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{

    public string itemName;
    public Sprite icon;
    public string itemDescription = "Item info"; 

    public virtual void Use()
    {
        Debug.Log("Using: " + itemName);
    }

    public virtual string GetItemDescription()
    {
        return itemDescription;
    }
}
