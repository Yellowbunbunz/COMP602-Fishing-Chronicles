using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayNightManager : MonoBehaviour
{
    // Variable set ups
    public TMP_Text timeText;        // To create a reference to the text
    private float currentTime = 0f;     // Variable for the current time
    private int inGameTime = 0;         // Variable for the current time but in game

    private const float cycleDuration = 1440f;       // Constant variable for 12 minutes in seconds (1 ingame day)
    private const float secondsToGameHours = 60f;   // Constant variable for how many real seconds to create 1 ingame day

    void Start()
    {
        inGameTime = Mathf.FloorToInt(currentTime / secondsToGameHours) + 6;
        UpdateTimeUI();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        int newTime = Mathf.FloorToInt(currentTime / secondsToGameHours) + 6;
        if (newTime != inGameTime)
        {
            inGameTime = newTime;
            UpdateTimeUI();
        }

        if(currentTime >= cycleDuration)
        {
            currentTime = 0f;
            inGameTime = 6;
            UpdateTimeUI();
        }
    }

    private void UpdateTimeUI()
    {
        int displayTime = (inGameTime % 24);
        timeText.text = string.Format("{0:00}:00", displayTime);
    }
}
