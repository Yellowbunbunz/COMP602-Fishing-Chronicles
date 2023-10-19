using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour
{
    public static GameMusic Instance;
    public static float vol;
    public AudioSource audioSource;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "MainWorld":
                GameMusic.Instance.PlaySong(0);
                break;
            case "FishingScene":
                GameMusic.Instance.PlaySong(1);
                break;
            case "Shop1":
                GameMusic.Instance.PlaySong(2);
                break;
        }
    }

    private void Update()
    {
        audioSource.volume = vol;
    }

    public void PlaySong(int songIndex)
    {
        // Check if the song index is valid.
        if (songIndex >= 0 && songIndex < audioClips.Length)
        {
            Debug.Log(audioSource.isPlaying);
            // If a song is already playing, stop it before changing to the new song.
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.clip = audioClips[songIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Invalid song index.");
        }
    }

}
