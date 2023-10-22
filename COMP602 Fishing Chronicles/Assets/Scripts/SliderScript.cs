using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image Fill;

    public void SetSliderMax(int max)
    {
        slider.maxValue = max;

        Fill.color = gradient.Evaluate(1f);
    }

    public void SetSlider(float value)
    {
        slider.value = value;

        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
