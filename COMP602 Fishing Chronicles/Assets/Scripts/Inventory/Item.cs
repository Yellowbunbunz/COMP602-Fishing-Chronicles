using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{

    public int ID;
    public string itemName;
    public int value;
    public Sprite icon;

    public virtual void Use()
    {
        Debug.Log("Using: " + itemName);
    }

}
