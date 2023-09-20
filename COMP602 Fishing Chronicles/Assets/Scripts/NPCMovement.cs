using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    int num = 0;
    bool flag = false;

    private void Start()
    {
        num = Random.Range(0, 7);
        force = Random.Range(250, 500);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //straight line
        if(num == 0)//forward
        {
            rb.AddForce(0, 0, force * Time.deltaTime);
        }
        if(num == 1)//backward
        {
            rb.AddForce(0, 0, -force * Time.deltaTime);
        }
        if(num == 2)//left
        {
            rb.AddForce(force * Time.deltaTime, 0, 0);
        }
        if(num == 3)//right
        {
            rb.AddForce(-force * Time.deltaTime, 0, 0);
        }
        //diagonal movement
        if (num == 4)//up right
        {
            rb.AddForce((force * Time.deltaTime) / 2, 0, (force * Time.deltaTime)/2);
        }
        if (num == 5)//down right
        {
            rb.AddForce((force * Time.deltaTime) / 2, 0, -force * Time.deltaTime);
        }
        if (num == 6)//down left
        {
            rb.AddForce(-(force * Time.deltaTime) / 2, 0, -(force * Time.deltaTime) / 2);
        }
        if (num == 7)//up left
        {
            rb.AddForce((-force * Time.deltaTime)/2, 0, (force * Time.deltaTime) / 2);
        }

        if (!flag)
        {
            int randomizer = Random.Range(0, 8);
            Invoke("turn", randomizer);
            flag = true;
        }
    }

    void turn()
    {
        num = Random.Range(0, 7);
        force = Random.Range(250, 500);
        flag = false;
    }
}
