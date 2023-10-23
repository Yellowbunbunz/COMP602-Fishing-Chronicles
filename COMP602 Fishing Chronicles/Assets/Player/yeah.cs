using UnityEngine;
using UnityEngine.SceneManagement;

public class yeah : MonoBehaviour
{
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
        Debug.Log(this.transform.position);
        // Add your custom code here, such as setting the player's position
    }
}
