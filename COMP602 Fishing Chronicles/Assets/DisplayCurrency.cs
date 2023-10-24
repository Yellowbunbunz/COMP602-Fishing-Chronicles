using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrency : MonoBehaviour
{

    public Text currency;
    public string label = "Currency: ";
    public static float currencyAmount;
    // Update is called once per frame
    void Update()
    {
        CurrencyUpdate();
    }


    public void CurrencyUpdate()
    {
        currency.text = label + currencyAmount;
    }
}
