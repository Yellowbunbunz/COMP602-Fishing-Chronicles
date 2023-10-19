using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainWorld");//loads the scene
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Debug.Log("exited app");
        Application.Quit();
    }
}
