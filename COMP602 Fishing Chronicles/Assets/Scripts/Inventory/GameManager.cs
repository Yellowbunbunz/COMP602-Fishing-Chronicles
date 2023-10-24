using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.WSA;

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

    public Transform canvas;
    public GameObject itemInfoPrefab;
    private GameObject currentItemInfo = null;

    public float moveX = -180;
    public float moveY = 100;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)) 
        {
            Item newItem = randomItems[Random.Range(0, randomItems.Count)];

            Inventory.Instance.AddItem(Instantiate(newItem));
        }
    }
    public void OnStatItemUse(StatItemTypes itemType, int amount)
    {
//        Debug.Log("Items sold: " + itemType + " for amount: " + amount);
    }

    public void DisplayItemInfo(string itemName, string itemDescription, Vector2 buttonPos)
    {
        if(currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }

        buttonPos.x += moveX;
        buttonPos.y += moveY;

        currentItemInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, canvas);
        currentItemInfo.GetComponent<ItemInfo>().SetUp(itemName, itemDescription);
    }

    public void DestroyItemInfo()
    {
        if(currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }
    }

}
