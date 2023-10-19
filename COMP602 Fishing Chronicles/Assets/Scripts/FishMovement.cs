using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    public float speed = 0.5f;
    public float changeDirectionInterval = 10.0f; // Time interval to change direction.
    public float maxDirectionChangeAngle = 180.0f; // Maximum angle change in degrees.
    public SpriteRenderer spriteRenderer;
    public GameObject water;
    Bounds waterBounds;



    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float changeDirectionTimer;

    private void Start()
    {
        initialPosition = transform.position;
        GetRandomTargetPosition();
    }

    private void FixedUpdate()
    {
        // Move towards the target position.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        // Flip the sprite if moving to the right.
        if (targetPosition.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        // Flip the sprite if moving to the left.
        else if (targetPosition.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }

        // Check if the fish has reached the target position.
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // It reached the target, so get a new random target position.
            GetRandomTargetPosition();
        }

        // Countdown to change direction.
        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer <= 0)
        {
            // Change direction by setting a new random target position.
            GetRandomTargetPosition();
            changeDirectionTimer = changeDirectionInterval;
        }

      
    }

    private void GetRandomTargetPosition()
    {
        // Generate a random angle.
        float randomAngle = Random.Range(-maxDirectionChangeAngle, maxDirectionChangeAngle);
        Collider2D waterBounds = water.GetComponent<BoxCollider2D>();

        // Calculate boundaries of the water rectangle.
        Vector2 waterBoundsMin = waterBounds.bounds.min;
        Vector2 waterBoundsMax = waterBounds.bounds.max;

        // Generate random position within the water boundaries.
       
        float randomX = Random.Range(waterBoundsMin.x, waterBoundsMax.x);
        float randomY = Random.Range(waterBoundsMin.y, waterBoundsMax.y);
        
        // Calculate the new target position based on the random angle.
        Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
        Vector3 direction = rotation * Vector3.right;
        targetPosition.x = Mathf.Clamp(initialPosition.x + randomX * direction.x, waterBoundsMin.x, waterBoundsMax.x);
        targetPosition.y = Mathf.Clamp(initialPosition.y + randomY * direction.y, waterBoundsMin.y, waterBoundsMax.y);
    }

}


