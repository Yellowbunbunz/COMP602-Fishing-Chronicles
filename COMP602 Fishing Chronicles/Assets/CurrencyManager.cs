using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyManager : MonoBehaviour
{

    public int money = 0;

    public static CurrencyManager Instance;

    public static int instanceCount = 0;

    public TMP_Text currencyText;

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

        instanceCount++;
        Debug.Log("CurrencyManager instance count: " + instanceCount);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrency();
    }

    private void UpdateCurrency()
    {
        currencyText.text = string.Format("{0:0}.00", money);
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
