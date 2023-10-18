using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWorldManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int fishCount = MainWorldSaver.fishInstance.fishCount;

        for (int i = 0; i < fishCount; i++)
        {
            Item fishItem = new Item();
            fishItem.itemName = "Fish";

            InventoryManager.Instance.Add(fishItem);
        }

        InventoryManager.Instance.ListItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
