using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterRod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (MerchantItemPickup.Instance != null)
        {
       //     Debug.Log("Yes Better Rod made it here!");
            MerchantItemPickup.Instance.Pickup();
        }
        else
        {
            Debug.Log("No I did not");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
