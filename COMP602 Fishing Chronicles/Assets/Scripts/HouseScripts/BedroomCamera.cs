using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomCamera : MonoBehaviour
{
    //All commenting done in EntranceCamera same code different locations.
    public Transform Ecamera;
    Vector3 Bedroom;
    Vector3 MainHallPos;

    private void Start()
    {
        Bedroom.Set(24.3f, 13, -22.5f);
        MainHallPos.Set(-22, 13.5f, 22);
    }
    private void OnTriggerEnter(Collider other)
    {
        Ecamera.transform.position = Bedroom;
    }
    private void OnTriggerExit(Collider other)
    {
        Ecamera.transform.position = MainHallPos;
    }
}
