using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    public GameObject plantPrefab; // Prefab with the PlantInstance script attached
    private Transform playerTransform;

    public List<GameObject> plantStagesType1; // Plant stages for type 1
    public List<GameObject> plantStagesType2; // Plant stages for type 2

    private Dictionary<string, List<GameObject>> plantStagesDict = new Dictionary<string, List<GameObject>>();

    void Start()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        // Initialize the dictionary with plant types
        plantStagesDict.Add("Type1", plantStagesType1);
        plantStagesDict.Add("Type2", plantStagesType2);
    }

    void Update()
    {
        // Check for the "T" key press to plant the seed
        if (Input.GetKeyDown(KeyCode.T) && playerTransform != null)
        {
            PlantSeed("Type1"); // Example: Plant Type1
        }
        else if (Input.GetKeyDown(KeyCode.Y) && playerTransform != null)
        {
            PlantSeed("Type2"); // Example: Plant Type2
        }
    }

    void PlantSeed(string plantType)
    {
        if (plantStagesDict.ContainsKey(plantType) && plantPrefab != null)
        {
            // Instantiate the plant prefab at the player's position
            GameObject newPlant = Instantiate(plantPrefab, playerTransform.position, playerTransform.rotation);
            PlantInstance plantInstance = newPlant.GetComponent<PlantInstance>();
            if (plantInstance != null)
            {
                plantInstance.plantStages = new List<GameObject>(plantStagesDict[plantType]);
                plantInstance.timePerStage = 3f; // Set the time per stage as needed
            }
        }
    }
}
