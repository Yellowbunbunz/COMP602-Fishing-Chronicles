using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTalking : MonoBehaviour
{
    bool entrance = true;
    static bool exit = true;
    static bool met = false;

    public void OnTriggerEnter(Collider collision)
    {
        //When a player enters it should make the npc say a "hello script"
        if (collision.tag == "Player" && entrance)
        {
            Invoke("firstSpeech", 1);
            entrance = false;
        }
        if(collision.tag == "Player" && met)
        {

        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player" && exit)
        {
            Invoke("exitSpeech", 1);
            exit = false;
        }
    }

    private void firstSpeech()
    {
        exit = true;
        Debug.Log("Welcome stranger");
    }

    private void exitSpeech()
    {
        met = true;
        Debug.Log("Farewell Stranger");

    }
}
