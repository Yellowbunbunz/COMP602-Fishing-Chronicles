using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(0);

    }


    private void OnDestroy()
    {
     //   PlayerPrefs.GameObject
    }
}
