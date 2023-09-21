using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCamera : MonoBehaviour
{
    //All commenting done in EntranceCamera same code different locations.
    public Transform Ecamera;
    Vector3 Storage;
    Vector3 MainHallPos;

    private void Start()
    {
        Storage.Set(-13.6f, 13, -22.5f);
        MainHallPos.Set(-22, 13.5f, 22);
    }
    private void OnTriggerEnter(Collider other)
    {
        Ecamera.transform.position = Storage;
    }
    private void OnTriggerExit(Collider other)
    {
        Ecamera.transform.position = MainHallPos;
    }
}
