using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    //audio business
    public AudioSource audioSource;
    public AudioClip sfxWalking;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //more audio business
            audioSource.clip = sfxWalking;
            audioSource.Play();
        }


    }
}
