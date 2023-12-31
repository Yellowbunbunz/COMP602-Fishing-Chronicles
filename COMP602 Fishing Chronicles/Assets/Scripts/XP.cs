using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XP : MonoBehaviour
{  
    public SliderScript slider;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        StandardVars.vars.MaxXP = StandardVars.vars.level * 100;
        StandardVars.vars.currentXP = 0;
        StandardVars.vars.level = 1;
        slider.SetSliderMax(StandardVars.vars.MaxXP);
        slider.SetSlider(StandardVars.vars.currentXP);
    }

    // Update is called once per frame
    void Update()
    {
        dispylayLevel(StandardVars.vars.level);
//        Debug.Log(vars.currentXP);
        slider.SetSlider(StandardVars.vars.currentXP);
    }

    public void dispylayLevel(int level)
    {
        levelText.text = "Level: "+ level;
    }
}
