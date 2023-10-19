using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public int money = 0;

    public static CurrencyManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("CurrencyManager Awake");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
        }
        else
        {
            Debug.Log("lol not enough dollarydoos");
        }
    }
}
