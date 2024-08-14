using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private PlantInstance nearbyPlant; // Store the reference to the nearby plant

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from WASD or arrow keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Check for the "F" key press to harvest the plant
        if (Input.GetKeyDown(KeyCode.F) && nearbyPlant != null && nearbyPlant.isHarvestable)
        {
            Debug.Log("Harvesting plant: " + nearbyPlant.name);
            nearbyPlant.Harvest();
            nearbyPlant = null; // Clear the reference after harvesting
        }
    }

    void FixedUpdate()
    {
        // Move the player using the Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Harvestable")
        {
            PlantInstance plantInstance = collision.gameObject.GetComponent<PlantInstance>();
            if (plantInstance != null && plantInstance.isHarvestable)
            {
                Debug.Log("Entered harvestable area: " + collision.gameObject.name);
                nearbyPlant = plantInstance; // Store the reference to the nearby plant
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Harvestable")
        {
            PlantInstance plantInstance = collision.gameObject.GetComponent<PlantInstance>();
            if (plantInstance != null && plantInstance == nearbyPlant)
            {
                Debug.Log("Exited harvestable area: " + collision.gameObject.name);
                nearbyPlant = null; // Clear the reference when the player exits the trigger area
            }
        }
    }
}
