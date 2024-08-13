using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    public Transform timeBarTransform; // Reference to the Transform component of the time bar
    public float totalTime = 10f; // Total time for one day in seconds
    public int totalDays = 7; // Total number of days to reach the quota

    private float currentTime;
    private int currentDay = 1;
    private Vector3 initialScale;

    public TextMeshProUGUI DaysCounter;

    void Start()
    {
        currentTime = totalTime; // Initialize the current time
        initialScale = timeBarTransform.localScale; 
    }

    void Update()
    {
        // Decrease the current time
        currentTime -= Time.deltaTime;

        // Update the time bar scale
        float scaleRatio = currentTime / totalTime;
        timeBarTransform.localScale = new Vector3(initialScale.x * scaleRatio, initialScale.y, initialScale.z);

        
        if (currentTime <= 0)
        {
            currentDay++; // Increment the day
            if (currentDay > totalDays)
            {
               
                Debug.Log("Quota reached or game over.");
                
            }
            else
            {
                currentTime = totalTime; 
            }
        }
    }
}
