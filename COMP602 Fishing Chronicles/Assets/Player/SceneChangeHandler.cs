using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeHandler : MonoBehaviour
{
    PlayerPosOnSpawn playerPos;

    private void Start()
    {
        playerPos = FindObjectOfType<PlayerPosOnSpawn>();

        // Ensure the player position is not null
        if (playerPos == null)
        {
            Debug.LogError("PlayerPosOnSpawn component not found on the player.");
        }
    }

    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Code to execute when a new scene is loaded
        Debug.Log("Scene loaded: " + scene.name);
        playerPos.ChangePlayerPosition(scene.name);
    }
}
