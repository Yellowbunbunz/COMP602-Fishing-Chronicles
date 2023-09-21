using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTalking : MonoBehaviour
{
    bool entrance = true;
    static bool exit = true;
    static bool met = false;
    int numw = 0;
    int numf = 0;
    int numt = 0;

    private void Start()
    {
        numw = Random.Range(0, 7);
        numf = Random.Range(0, 7);
        numt = Random.Range(0, 7);
    }

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
            numt++;
            Invoke("talkSpeech", 1);
            met = false;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player" && exit)
        {
            numf++;
            Invoke("exitSpeech", 1);
            exit = false;
        }
    }

    private void firstSpeech()
    {
        if(numw == 0)
        {
            Debug.Log("Welcome stranger");
        }
        else if (numw == 1)
        {
            Debug.Log("Welcome to our town of unassigned fishing village");
        }
        else if (numw == 2)
        {
            Debug.Log("Hey, I haven't seen you before");
        }
        else if (numw == 3)
        {
            Debug.Log("A new face? How delightful");
        }
        else if (numw == 4)
        {
            Debug.Log("Our town is pretty friendly to new comers!");
        }
        else if (numw == 5)
        {
            Debug.Log("We don't like new comers round these parts...");
        }
        else if (numw == 6)
        {
            Debug.Log("Oooo, where are you from?");
        }
        else if (numw == 7)
        {
            Debug.Log("Ooooo, my oh my, haven't seen a new person round these parts in a while");
        }

    }

    private void exitSpeech()
    {
        met = true;
        if (numf == 0)
        {
            Debug.Log("Farewell!");
        }
        else if (numf == 1)
        {
            Debug.Log("Come back any time!");
        }
        else if (numf == 2)
        {
            Debug.Log("Would say farewell, but I'd rather you don't fair well...");
        }
        else if (numf == 3)
        {
            Debug.Log("Can't wait to see you again!");
        }
        else if (numf == 4)
        {
            Debug.Log("Always a pleasure seeing your face.");
        }
        else if (numf == 5)
        {
            Debug.Log("Until next time!");
        }
        else if (numf == 6)
        {
            Debug.Log("Don't come here again!");
        }
        else if (numf == 7)
        {
            Debug.Log("Gotta get going, so soon? Oh well.");
        }
        numf = Random.Range(0, 7);
    }

    private void talkSpeech()
    {
        exit = true;
        if (numt == 0)
        {
            Debug.Log("*stares intensely*");
        }
        else if (numt == 1)
        {
            Debug.Log("*sigh* Don't have time for your antics now.");
        }
        else if (numt == 2)
        {
            Debug.Log("Bacon.");
        }
        else if (numt == 3)
        {
            Debug.Log("Hello again Fisherman!");
        }
        else if (numt == 4)
        {
            Debug.Log("We meet again.");
        }
        else if (numt == 5)
        {
            Debug.Log("ew, you again.");
        }
        else if (numt == 6)
        {
            Debug.Log("Go away!");
        }
        else if (numt == 7)
        {
            Debug.Log("Move, I'm busy.");
        }
        numt = Random.Range(0, 7);

    }
}
