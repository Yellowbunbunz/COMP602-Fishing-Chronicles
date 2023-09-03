using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayNightManager : MonoBehaviour
{
    // Reference variables to the TextMeshPro texts
    public TMP_Text timeText;           
    public TMP_Text dayText;

    // Varaibles for storing time and days
    private float currentTime = 0f;     
    private int inGameTime = 0;         
    private int inGameDay = 1;

    // Constant varaibles for the time calculations
    private const float cycleDuration = 1440f;       // 12 minutes in seconds (1 ingame day)
    private const float secondsToGameHours = 60f;    // How many real seconds to create 1 ingame hour


    void Start()
    {
        // Initialising the ingame time and day and startup
        inGameTime = Mathf.FloorToInt(currentTime / secondsToGameHours) + 6;    // ChatGPT helped me with this math
        inGameDay = 1;

        // Updating the UI with the initial time and day
        UpdateTimeUI();     
    }

    void Update()
    {
        // Updating the current time with real time seconds
        currentTime += Time.deltaTime;

        // Calculating the new ingame time
        int newTime = Mathf.FloorToInt(currentTime / secondsToGameHours) + 6;   // ChatGPT helped me with this math too 

        // Checking if the ingame time has changed
        if (newTime != inGameTime)
        {
            // If it has, update the ingame time and the UI
            inGameTime = newTime;
            UpdateTimeUI();
        }

        // Checking if a full ingame day has passed
        if(currentTime >= cycleDuration)
        {
            // Resetting the time and start time to how it was initialised as
            currentTime = 0f;
            inGameTime = 6;

            // Increment the day by 1
            inGameDay++;

            // Update the UI
            UpdateTimeUI();
        }
    }

    // This method updates the UI elements when called
    private void UpdateTimeUI()
    {
        // Put the time within a 24 hour time format
        int displayTime = (inGameTime % 24);

        // Updates the time text within the format of Hour:Minute
        timeText.text = string.Format("{0:00}:00", displayTime);

        // Updates the day text with the current ingame day
        dayText.text = string.Format("{0}", inGameDay);
    }
}
