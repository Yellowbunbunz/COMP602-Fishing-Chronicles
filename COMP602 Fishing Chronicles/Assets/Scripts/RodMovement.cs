using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public SpriteRenderer water; // Reference to the sprite background.

    private Bounds bounds;
    private float offset = 0.05f;

    void Start()
    {
        if (water != null)
        {
            bounds = water.bounds;
        }
        else
        {
            Debug.LogError("Background sprite not assigned.");
        }
    }

    void Update()
    {
        if (water == null)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the bounds of the background.
        float clampedX = Mathf.Clamp(newPosition.x, bounds.min.x, bounds.max.x);
        float clampedY = Mathf.Clamp(newPosition.y , bounds.min.y - offset, bounds.max.y - offset);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
