using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XP : MonoBehaviour
{
    public int currentXP;
    public int MaxXP;
    public int level = 1;

    public SliderScript slider;

    // Start is called before the first frame update
    void Start()
    { 
        currentXP = 0;
        MaxXP = level * 100;

        slider.SetSliderMax(MaxXP);
        slider.SetSlider(currentXP);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            getXP(10);
        }
    }

    public void getXP(int xp)
    {
        currentXP += xp;
        slider.SetSlider(currentXP);

        if(currentXP>= MaxXP)
        {
            level++;
            MaxXP = level * 100;
            slider.SetSliderMax(MaxXP);
            currentXP = 0;
            slider.SetSlider(currentXP);
        }
    }
}
