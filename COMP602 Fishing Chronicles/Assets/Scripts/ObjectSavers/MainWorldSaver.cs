using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainWorldSaver : MonoBehaviour
{
    //All this code is from StoreObjectsData, any comments regarding this code are placed in there. Same code
    //1 name changed.
    private static MainWorldSaver _instance;
    private string startScene;

    public static MainWorldSaver fishInstance;
    public int fishCount = 0;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (startScene == null)
        {
            startScene = SceneManager.GetActiveScene().name;
        }
        if (_instance != null)
        {
            if (scene.name == startScene)
            {
                this.gameObject.SetActive(true);
            }
            if (scene.name != startScene)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
