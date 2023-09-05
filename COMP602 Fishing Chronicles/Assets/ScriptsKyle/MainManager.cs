using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    //currently this entire script does nothing but make an object in the DontDestroyOnLoad
    //thinking this will be used later for everyone to be able to keep certain data across areas.
    public static MainManager Instance;
    public Object objects;
    public Scene saveScene;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

}
