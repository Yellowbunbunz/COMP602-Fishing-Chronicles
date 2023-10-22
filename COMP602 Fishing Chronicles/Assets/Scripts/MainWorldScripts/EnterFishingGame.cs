using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterFishingGame : MonoBehaviour
{
    bool fish = false;

    private void Start()
    {
        Debug.Log(fish);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            fish = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            fish = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && fish)
        {
            SceneManager.LoadScene("FishingScene");//loads the scene
        }
    }
}
