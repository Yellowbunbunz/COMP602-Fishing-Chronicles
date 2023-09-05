using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseM : MonoBehaviour
{
    public float speedX = 1f;
    public float speedY = 1f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        xRotation += speedX * Input.GetAxis("Mouse X");
        yRotation -= speedY * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3 (yRotation - 5,xRotation, 0f);

    }
}
