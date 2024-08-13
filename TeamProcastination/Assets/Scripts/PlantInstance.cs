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
        }
    }
}
