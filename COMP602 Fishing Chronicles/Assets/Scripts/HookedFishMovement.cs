using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HookedFishMovement : MonoBehaviour
{
    private bool isHooked = false;
    private float releaseTime = 10.0f; // Time in seconds before releasing if not pulled to the top.
    private float releaseTimer = 0.0f;
    public float rodForce = 10;
    public RodMovement rod;
    public FishMovement fish;
    public FishSpawner fishSpawner;
    public GameObject water;
    Bounds waterBounds;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHooked)
        {
            rod.enabled = false;
            fish.enabled = false;
            // Fish is hooked, apply diagonal pull here.
            // You can use transform.Translate or Rigidbody2D for movement.
            // For simplicity, we'll move the fish diagonally downwards.
            transform.Translate(Vector3.down * Time.deltaTime);
            FightFish();
            // Check if the fish has been pulled to the top.
            waterBounds = water.GetComponent<SpriteRenderer>().bounds;
            if (transform.position.y >= waterBounds.min.y)
            {
                // Fish is at the top, release it.
                DeleteFish();
            }
            else
            {
                // Fish is still hooked, start the release timer.
                releaseTimer += Time.deltaTime;

                // Check if it's time to release the fish.
                if (releaseTimer >= releaseTime)
                {
                    ReleaseFish();
                }
            }
        }

        void FightFish()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * rodForce * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {

                transform.Translate(Vector2.right * rodForce * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * rodForce * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {

                transform.Translate(Vector2.down * rodForce* Time.deltaTime);
            }
        }

         void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Hook"))
            {
                isHooked = true;
                Debug.Log("Hooked");
            }
        }

         void ReleaseFish()
        {
            // Release the fish.
            isHooked = false;
            rod.enabled = true;
            fish.enabled = true;
            releaseTimer = 0.0f;
        }

         void DeleteFish()
        {
            // Delete the fish and decrease the fish count.
            if (fishSpawner != null)
            {
                fishSpawner.DecreaseFish();
            }
            Destroy(gameObject);
            rod.enabled = true;
            fish.enabled = true;
        }
    }
}
