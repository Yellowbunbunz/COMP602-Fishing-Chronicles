using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitAtAnyTime : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && SceneManager.GetActiveScene().name == "FishingScene")
        {
            SceneManager.LoadScene("MainWorld");//loads the scene
            player.SetActive(true);
        }
    }
}
