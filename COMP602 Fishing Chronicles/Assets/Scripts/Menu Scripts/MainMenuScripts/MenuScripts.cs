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

    public void Quit()
    {
        //this will close the app but only once exported cannot close unity
        Debug.Log("exited app");
        Application.Quit();
    }
}
