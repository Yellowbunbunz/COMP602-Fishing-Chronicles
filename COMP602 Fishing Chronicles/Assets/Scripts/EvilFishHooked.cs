using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilFishHooked : MonoBehaviour
{

    private bool isHooked = false;
    private float releaseTime = 5.0f; // Time in seconds before releasing if not pulled to the top.
    private float releaseTimer = 0.0f;
    public float fishspeed = 11.0f;
    public float rodForce = 10f;
    public FishMovement fish;
    public GameObject water;
    private GameObject hook;
    Collider2D waterBounds;



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

                // Fish is still hooked, start the release timer.
                releaseTimer += Time.deltaTime;

                // Check if it's time to release the fish.
                if (releaseTimer >= releaseTime)
                {
                    ReleaseFish();
                    fish.enabled = true;
                }
                else if(hook.transform.position.y >= waterBoundsMax.y)
                {
                    Destroy(hook);
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
