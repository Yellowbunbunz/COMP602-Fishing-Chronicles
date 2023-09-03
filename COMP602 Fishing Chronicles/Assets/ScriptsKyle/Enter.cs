using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    public movement move;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Door")
        {
            SceneManager.LoadScene(1);
        }
        if (collision.collider.tag == "MainScene")
        {
            SceneManager.LoadScene(0);
        }
    }
}
