using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempCameraFollow : MonoBehaviour
{
    //this is mostly just a temporary idea until a better camera model can be found.
    //So in any small room, we can have a stationary camera that turns around to follow player.
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
