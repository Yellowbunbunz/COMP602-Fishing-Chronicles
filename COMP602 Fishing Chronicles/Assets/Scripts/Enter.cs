using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //This holds tags that are safe to change scenes to, so to change to scene House use the tag "house".
        //Now I'm using an array and looping though it, so I can easily just add 1 line to the array and it
        //will now work for the new scene.
        string[] safetags = { "Shop1", "MainWorld", "House" };
        for(int i = 0; safetags.Length > i; i++)
        {
            if (collision.collider.tag == safetags[i])
            {
                SceneManager.LoadScene(collision.collider.tag);//loads the scene
            }

        }
    }
}
