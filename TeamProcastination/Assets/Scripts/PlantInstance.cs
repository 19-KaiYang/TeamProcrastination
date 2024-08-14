using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInstance : MonoBehaviour
{
    public List<GameObject> plantStages; // List of plant stage prefabs
    public float timePerStage = 3f; // Time in seconds for each growth stage
    private int currentStage = 0;
    private float currentTime = 0f;
    private GameObject currentPlant;
    public bool isHarvestable = false; // Track if the plant is harvestable

    void Start()
    {
        if (plantStages.Count > 0)
        {
            // Instantiate the initial plant stage
            currentPlant = Instantiate(plantStages[currentStage], transform.position, transform.rotation, transform);
        }
    }

    void Update()
    {
        if (isHarvestable)
        {
            return; // Do not update if the plant is harvestable
        }

        // Update the elapsed time
        currentTime += Time.deltaTime;

        // Check if it's time to switch to the next stage
        if (currentTime >= timePerStage)
        {
            currentTime = 0f; // Reset the timer
            currentStage++; // Move to the next stage

            // Check if there are more stages
            if (currentStage < plantStages.Count)
            {
                // Destroy the current plant
                if (currentPlant != null)
                {
                    Destroy(currentPlant);
                }

                // Instantiate the next plant stage
                currentPlant = Instantiate(plantStages[currentStage], transform.position, transform.rotation, transform);
            }
            else
            {
                isHarvestable = true; // Mark as harvestable if it reaches the last stage
                gameObject.tag = "Harvestable"; // Set the tag to Harvestable
                Debug.Log("Plant has reached harvestable stage.");
            }
        }
    }

    public void Harvest()
    {
        if (isHarvestable)
        {
            Debug.Log("Harvesting plant: " + name);
            Destroy(gameObject); // Destroy the plant game object when harvested
        }
    }
}
