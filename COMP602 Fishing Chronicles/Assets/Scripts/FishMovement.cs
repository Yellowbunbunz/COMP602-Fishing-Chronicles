using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    public float speed = 0.5f;
    public float changeDirectionInterval = 10.0f; // Time interval to change direction.
    public float maxDirectionChangeAngle = 360.0f; // Maximum angle change in degrees.
    public GameObject water;

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
        Bounds waterBounds = water.GetComponent<SpriteRenderer>().bounds;

        float randX = Random.Range(waterBounds.min.x, waterBounds.max.x);
        float randY = Random.Range(waterBounds.min.y, waterBounds.max.y);

        // Calculate the new target position based on the random angle.
        Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
        Vector3 direction = rotation * Vector3.right;
        targetPosition = new Vector3(initialPosition + direction * randX, initialPosition + direction * randX,0);
    }
}
