using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Slider slider;
    public static float num;
    public void OnEnable()
    {
        slider.value = num;
    }
    public void SetVolume(float volume)
    {
        num = volume;
        GameMusic.vol = volume;
    }
}
