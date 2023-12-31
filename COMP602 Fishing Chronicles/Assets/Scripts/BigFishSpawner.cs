using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public float spawnInterval = 5.0f;
    public int maxFishCount = 5;

    public GameObject water;
    public GameObject parent;

    private int currentFishCount = 0;

    private void Start()
    {
        InvokeRepeating("SpawnFish", 0.0f, spawnInterval);
        fishPrefab.SetActive(false);
    }

    private void SpawnFish()
    {
        if (currentFishCount < maxFishCount)
        {
            // Calculate boundaries of the water rectangle.
            Collider2D waterBounds = water.GetComponent<BoxCollider2D>();

            // Calculate boundaries of the water rectangle.
            Vector2 waterBoundsMin = waterBounds.bounds.min;
            Vector2 waterBoundsMax = waterBounds.bounds.max;

            // Generate random position within the water boundaries.
            float randomX = Random.Range(waterBoundsMax.x, waterBoundsMin.x);
            float randomY = Random.Range(waterBoundsMax.y, waterBoundsMin.y);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            GameObject newFish = Instantiate(fishPrefab, spawnPosition, Quaternion.identity, parent.transform);
            newFish.SetActive(true);
            currentFishCount++;
        
        }
    }

    public void DecreaseFish()
    {
        currentFishCount--;
    }
}
