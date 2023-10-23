using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "StatItem", menuName = "Item/Create New Item")]

public class StatItem : Item
{
    public StatItemTypes itemType;
    public int amount;
    
    public override void Use()
    {
        base.Use();
        GameManager.instance.OnStatItemUse(itemType, amount);
        Inventory.Instance.RemoveItem(this);
    }

}

public enum StatItemTypes
{
    plainFish,
    bigFish,
    rod
}
