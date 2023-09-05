using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XP : MonoBehaviour
{
    public int currentXP;
    public int MaxXP;
    public int level = 1;

    public SliderScript slider;
    public Text levelText;

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
            getXP(70);
        }
        dispylayLevel(level);
    }

    public void dispylayLevel(int level)
    {
        levelText.text = "Level: "+ level;
    }
    public void getXP(int xp)
    {
        currentXP += xp;
        slider.SetSlider(currentXP);

        if(currentXP>= MaxXP)
        {
            int Xpdiff = currentXP - MaxXP;
            level++;
            MaxXP = level * 100;
            slider.SetSliderMax(MaxXP);
            currentXP = Xpdiff;
            slider.SetSlider(currentXP);
        }
    }
}
