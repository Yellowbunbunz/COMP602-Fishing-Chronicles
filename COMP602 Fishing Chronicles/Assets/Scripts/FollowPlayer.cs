using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float xOffset= 0, yOffset = 5, zOffset = -8;
    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
        
    }

    public void Follow()
    {
        transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
    }
}
