using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    #endregion

   public List<StatItem> randomItems = new List<StatItem>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)) 
        {
            Inventory.Instance.AddItem(randomItems[Random.Range(0, randomItems.Count)]);
        }
    }
    public void OnStatItemUse(StatItemTypes itemType, int amount)
    {
        Debug.Log("Items sold: " + itemType + " for amount: " + amount);
    }

}
