using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody rb;

    public float sidewaysforce = 100f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))//goes forward
        {
            rb.AddForce(0, 0, sidewaysforce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))//goes backward
        {
            rb.AddForce(0, 0, -sidewaysforce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))//goes go right
        {
            rb.AddForce(sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))//go left
        {
            rb.AddForce(-sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
