using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public float initialSpeed = 2.0f;
    public float maxSpeed = 8.0f;
    public float chaseDistance = 10.0f;

    private Transform closestFish;
    private Rigidbody2D sharkRigidbody;

    private void Start()
    {
        sharkRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FindClosestFish();
        if (closestFish != null)
        {
            Vector3 direction = closestFish.position - transform.position;
            float distanceToFish = direction.magnitude;

            // Adjust the shark's speed based on the distance to the fish.
            float lerpFactor = Mathf.Clamp01(distanceToFish / chaseDistance);
            float currentSpeed = Mathf.Lerp(initialSpeed, maxSpeed, lerpFactor);

            // Move the shark towards the fish.
            sharkRigidbody.velocity = direction.normalized * currentSpeed;
           
            // Check if the shark is close enough to eat the fish.
            if (distanceToFish <= 0.1f) 
            {
                // Remove the fish when the shark reaches it.
                Destroy(closestFish.gameObject);
            }
        


        }
    }

    private void FindClosestFish()
    {
        GameObject[] fishArray = GameObject.FindGameObjectsWithTag("Fish");
        float closestDistance = Mathf.Infinity;
        closestFish = null;

        foreach (GameObject fish in fishArray)
        {
            float distance = Vector3.Distance(transform.position, fish.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestFish = fish.transform;
            }
        }
    }
}
