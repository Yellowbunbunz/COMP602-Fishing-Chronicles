using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellingBox : MonoBehaviour
{
    public InventoryManager inventoryManager;
    static InventoryItemController inventoryItemController;

    float interactionRadius = 5.0f;

    private void SetInventoryItemController(InventoryItemController controller)
    {
        inventoryItemController = controller;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && IsPlayerNearby())
        {
            if (inventoryManager != null)
            {
                if (inventoryManager.isInventoryOpen)
                {
                    inventoryManager.CloseInventory();
                    HideSellButton();
                }
                else
                {
                    inventoryManager.OpenInventory();
                    ShowSellButton();
                }
            }
        }
    }

    private bool IsPlayerNearby()
    {
        float distance = Vector3.Distance(transform.position, PlayerManager.instance.transform.position);
        return distance <= interactionRadius;
    }
    private void ShowSellButton()
    {
        InventoryItemController[] itemControllers = inventoryManager.ItemContent.GetComponentsInChildren<InventoryItemController>();
        foreach (var itemController in itemControllers)
        {
            itemController.ShowSellButton();
        }
    }

    private void HideSellButton()
    {
        InventoryItemController[] itemControllers = inventoryManager.ItemContent.GetComponentsInChildren<InventoryItemController>();
        foreach (var itemController in itemControllers)
        {
            itemController.HideSellButton();
        }
    }
}
