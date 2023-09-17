using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodMovement : MonoBehaviour
{
    public float speed = 1.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)) { 
            
            transform.Translate(Vector2.right * speed * Time.deltaTime); 
        }
        if( Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) {

            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}
