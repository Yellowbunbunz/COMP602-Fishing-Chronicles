using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    public GameObject gameObject;

    void OnCollisionEnter(Collision collision)
    {
       if (collision.collider.tag == "Door")
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByBuildIndex(1));
            //SceneManager.LoadScene(1, LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        }
        if (collision.collider.tag == "MainScene")
        {
            SceneManager.LoadScene(0);
        }
    }
}
