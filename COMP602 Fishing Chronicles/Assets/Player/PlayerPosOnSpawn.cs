using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerPosOnSpawn : MonoBehaviour
{
    private List<Vector3> vector3s = new List<Vector3>();
    private Transform playerTransform;

    private void Start()
    {
        DontDestroyOnLoad(this);

        // Initialize the Vector3 positions in the list
        vector3s.Add(this.transform.position);
        vector3s.Add(new Vector3(-14f, 0.25f, -13.5f));
        vector3s.Add(new Vector3(-22f, 0.25f, -19f));

        playerTransform = transform;
    }

    public void ChangePlayerPosition(string sceneName)
    {
        switch (sceneName)
        {
            case "MainWorld":
                // Change the player's position based on the loaded scene
                playerTransform.position = vector3s[0];
                break;
            case "Shop1":
                playerTransform.position = vector3s[1];
                break;
            case "House":
                playerTransform.position = vector3s[2];
                break;
            // Add more cases for other scenes as needed
            default:
                // Handle other scenes or any specific logic
                gameObject.SetActive(false); // Disable the object in unhandled scenes
                break;
        }
    }
}

