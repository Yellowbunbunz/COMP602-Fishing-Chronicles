using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTalking : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("you've exited");

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if(collision.collider.tag == "Player")
        {
            Debug.Log("Hello there stranger");
        }
    }
}
