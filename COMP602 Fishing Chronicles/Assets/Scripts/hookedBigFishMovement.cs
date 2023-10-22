using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookedBigFishMovement : MonoBehaviour
{

    private bool isHooked = false;
    private float releaseTime = 5.0f; // Time in seconds before releasing if not pulled to the top.
    private float releaseTimer = 0.0f;
    public float fishspeed = 0.7f;
    public float rodForce = 10f;
    public FishMovement fish;
    public BigFishSpawner bigFishSpawner;
    public GameObject water;
    private GameObject hook;
    Collider2D waterBounds;

    public static ItemPickup Instance;


    // Update is called once per frame
    void FixedUpdate()
    {


        if (isHooked)
        {

            fish.enabled = false;
            // Fish is hooked, apply diagonal pull here.
            hook.transform.Translate(Vector3.down * Time.deltaTime * fishspeed);

            //hooked fished movement
            Vector3 hookPosition = hook.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, hookPosition, rodForce * Time.deltaTime);

            // Check if the fish has been pulled to the top.
            Collider2D waterBounds = water.GetComponent<BoxCollider2D>();

            // Calculate boundaries of the water rectangle.
            Vector2 waterBoundsMax = waterBounds.bounds.max;

            if (hook.transform.position.y >= waterBoundsMax.y)
            {
                // Fish is at the top, release it.
                DeleteFish();

                //if (ItemPickup.Instance != null)
                //{
                //    ItemPickup.Instance.Pickup();
                //}
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

        void ReleaseFish()
        {
            // Release the fish.
            isHooked = false;
            fish.enabled = true;
            hook = null;
            releaseTimer = 0.0f;
        }

        void DeleteFish()
        {
            // Delete the fish and decrease the fish count.
            if (bigFishSpawner != null)
            {
                bigFishSpawner.DecreaseFish();
            }
            Destroy(gameObject);
            fish.enabled = true;
            hook = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hook")
        {
            isHooked = true;
            hook = other.gameObject;

        }
    }
}
