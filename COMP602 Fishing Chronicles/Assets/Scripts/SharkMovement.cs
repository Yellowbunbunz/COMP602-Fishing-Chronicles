using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public float initialSpeed = 2.0f;
    public float maxSpeed = 8.0f;
    public float detectionRadius = 5.0f;
    public float eatCooldown = 3.0f; 
    public float maxDirectionChangeAngle = 180f;
    public float changeDirectionInterval = 10.0f;
    public SpriteRenderer spriteRenderer;
    public GameObject water;
    public FishSpawner fishSpawner;
    public BigFishSpawner bigFishSpawner;

    private Transform closestFish;
    private Rigidbody2D sharkRigidbody;
    private float lastEatTime;
    private float changeDirectionTimer;
    private Bounds waterBounds;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isChasingFish = false;

    private void Start()
    {
        sharkRigidbody = GetComponent<Rigidbody2D>();
        lastEatTime = 0.0f;
        initialPosition = transform.position;
        GetRandomTargetPosition();
        waterBounds = water.GetComponent<BoxCollider2D>().bounds;
        changeDirectionTimer = changeDirectionInterval;

    }

    private void FixedUpdate()
    {
        if (targetPosition.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }

        if (Time.time - lastEatTime >= eatCooldown)
        {
            FindClosestFish();
            if (closestFish != null)
            {
                Vector3 direction = closestFish.position - transform.position;
                float distanceToFish = direction.magnitude;

                // Check if the fish is within the detection radius.
                if (distanceToFish <= detectionRadius)
                {
                    // Move the shark towards the fish at max speed.
                    sharkRigidbody.velocity = direction.normalized * maxSpeed;

                    // Check if the shark is close enough to eat the fish.
                    if (distanceToFish <= 0.5f) 
                    {
                        // Remove the fish when the shark reaches it.
                        if(closestFish.tag == "Fish")
                        {
                            fishSpawner.DecreaseFish();
                            Destroy(closestFish.gameObject);
                            lastEatTime = Time.time;
                        }
                        if(closestFish.tag == "BigFish")
                        {
                            bigFishSpawner.DecreaseFish();
                            Destroy(closestFish.gameObject);
                            lastEatTime = Time.time;
                        } 
                    }

                    isChasingFish = true;
                }
                else
                {
                    // Fish is outside the detection radius, stop moving.
                    Movement();
                    isChasingFish = false;
                }
            }
            else
            {
                // No fish detected, swim towards the target position.
                Movement();
                isChasingFish = false;
            }
        }
        else
        {
            // Wait until the eat cooldown expires.
            Movement();
            isChasingFish = false;
        }
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, initialSpeed * Time.deltaTime);
        // Check if it's time to change direction.
        changeDirectionTimer -= Time.deltaTime;
        if (changeDirectionTimer <= 0)
        {
            // Change direction by setting a new random target position.
            GetRandomTargetPosition();
            changeDirectionTimer = changeDirectionInterval;
        }

        // Move the shark towards the target position at the initial speed.
        Vector2 direction = (targetPosition - transform.position).normalized;
        sharkRigidbody.velocity = direction * initialSpeed;
    }

    private void FindClosestFish()
    {
        GameObject[] fishArray = GameObject.FindGameObjectsWithTag("Fish");
        GameObject[] bigFishArray = GameObject.FindGameObjectsWithTag("BigFish");
        GameObject[] allFish = fishArray.Concat(bigFishArray).ToArray();

        float closestDistance = detectionRadius;
        closestFish = null;

        foreach (GameObject fish in allFish)
        {
            float distance = Vector3.Distance(transform.position, fish.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestFish = fish.transform;
            }
        }
    }

    private void GetRandomTargetPosition()
    {
        // Generate a random angle.
        float randomAngle = Random.Range(-maxDirectionChangeAngle, maxDirectionChangeAngle);

        // Generate random position within the water boundaries.
        float randomX = Random.Range(waterBounds.min.x, waterBounds.max.x);
        float randomY = Random.Range(waterBounds.min.y, waterBounds.max.y);

        // Calculate the new target position based on the random angle.
        Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
        Vector3 direction = rotation * Vector3.right;
        targetPosition.x = Mathf.Clamp(initialPosition.x + randomX * direction.x, waterBounds.min.x, waterBounds.max.x);
        targetPosition.y = Mathf.Clamp(initialPosition.y + randomY * direction.y, waterBounds.min.y, waterBounds.max.y);
    }
}
