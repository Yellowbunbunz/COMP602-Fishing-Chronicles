using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    float interactionRadius = 10;
    public static NPCInteraction instance;
    
    private void Awake()
    {
        instance = this; 
    }

    public bool isPlayerNearby()
    {
        float distance = Vector3.Distance(transform.position, PlayerManager.instance.transform.position);

        return distance <= interactionRadius;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby())
        {
            //Debug.Log("player is nearby");
        }
    }
}
