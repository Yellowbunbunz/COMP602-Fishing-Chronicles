using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public SliderScript slider;
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.SetSliderMax(maxHealth);
        slider.SetSlider(currentHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) 
        {
            damge(10);
        }
    }

    public void damge(int damge)
    {
        currentHealth -= damge;
        slider.SetSlider(currentHealth);
    }
}
