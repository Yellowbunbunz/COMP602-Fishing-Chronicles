using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceCamera : MonoBehaviour
{
    public Transform Ecamera;
    //setting up the location of the camera that will point into the desired room.
    Vector3 Entrance;
    //setting up the location of the main room
    Vector3 MainHallPos;

    private void Start()
    {
        Entrance.Set(-13.6f, 13, -16.5f);//set room
        MainHallPos.Set(-22, 13.5f, 22);//set main room
    }
    //when player spawns in or walks into this room it will now move the camera to the appropriate locations.
    private void OnTriggerEnter(Collider other)
    {
        Invoke("enter", 3);
    }
    private void OnTriggerExit(Collider other)
    {
        Invoke("exit", 3);
    }
    void enter()
    {
        Ecamera.transform.position = Entrance;
    }
    void exit()
    {
        Ecamera.transform.position = MainHallPos;

    }

}
