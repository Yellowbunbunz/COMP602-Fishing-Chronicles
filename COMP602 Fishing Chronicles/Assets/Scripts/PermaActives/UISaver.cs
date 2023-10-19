using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISaver : MonoBehaviour
{
    public static UISaver Instance;

    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
}
