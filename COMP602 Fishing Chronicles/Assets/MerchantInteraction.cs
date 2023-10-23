using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantInteraction : MonoBehaviour
{
    float interactionRadius = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && IsPlayerNearby())
        {
            if (MerchantInventoryManager.Instance.isInventoryOpen)
            {
                MerchantInventoryManager.Instance.CloseInventory();
            }
            else
            {
                MerchantInventoryManager.Instance.OpenInventory();
            }
        }
    }

    private bool IsPlayerNearby()
    {
        float distance = Vector3.Distance(transform.position, PlayerManager.instance.transform.position);
        return distance <= interactionRadius;
    }
}
