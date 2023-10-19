using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public void SetVolume(float volume)
    {
        GameMusic.vol = volume;
    }
}
