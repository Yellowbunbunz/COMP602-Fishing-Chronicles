using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour
{
    public static GameMusic Instance;
    public static float vol;
    public AudioSource audioSource;
    private bool songChange = false;

    public AudioClip[] audioClips;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        audioSource.volume = vol;
        if(SceneManager.GetActiveScene().name == "MainWorld")
        {
            songChange = false;
            audioSource.clip = audioClips[0];
        }
    }

}
