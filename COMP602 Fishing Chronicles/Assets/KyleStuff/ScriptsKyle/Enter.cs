using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        string[] safetags = { "Shop1", "SampleScene", "House" };
        for(int i = 0; safetags.Length > i; i++)
        {
            if (collision.collider.tag == safetags[i])
            {
                SceneManager.LoadScene(collision.collider.tag);
            }

        }
    }
}
