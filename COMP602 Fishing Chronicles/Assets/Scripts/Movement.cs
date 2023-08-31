using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;
    public float jumpSpot = 2;
    public float jumpForce = 1000;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && jumpSpot <= 2)
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0);
        }
    }
}
