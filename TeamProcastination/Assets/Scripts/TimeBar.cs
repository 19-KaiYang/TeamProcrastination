using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeBar : MonoBehaviour
{
    public Transform timeBarTransform;
    public float totalTime = 120f; // Total time for one day in seconds
    public int totalDays = 7;

    private float currentTime;
    private int currentDay = 1;
    private Vector3 initialScale;

    public TextMeshProUGUI daysCounter;

    // Singleton instance
    private static TimeBar instance;

    void Awake()
    {
        // If an instance already exists and it's not this one, destroy this instance
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this instance as the singleton instance and mark it to not be destroyed on load
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        currentTime = totalTime; // Initialize the current time
        initialScale = timeBarTransform.localScale;
        UpdateDaysCounter(); // Update the counter at the start
    }

    void Update()
    {
        // Decrease the current time
        currentTime -= Time.deltaTime;

        // Update the time bar scale
        float scaleRatio = currentTime / totalTime;
        timeBarTransform.localScale = new Vector3(initialScale.x * scaleRatio, initialScale.y, initialScale.z);
        UpdateDaysCounter(); // Update the days counter every frame

        if (currentTime <= 0)
        {
            currentDay++; // Increment the day
            if (currentDay > totalDays)
            {
                Debug.Log("Quota reached or game over.");
                // You can add your game over logic here
            }
            else
            {
                currentTime = totalTime; // Reset the time for the next day
            }
        }

        if(Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("SaveandLoadTest");
        }
    }

    void UpdateDaysCounter()
    {
        if (daysCounter != null)
        {
            daysCounter.text = $"Days: {currentDay} / {totalDays}";
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the UI elements in the new scene
        Transform newTimeBarTransform = GameObject.Find("TimeBarTransform")?.transform;
        TextMeshProUGUI newDaysCounter = GameObject.Find("DaysCounter")?.GetComponent<TextMeshProUGUI>();

        if (newTimeBarTransform != null && newDaysCounter != null)
        {
            SetUIElements(newTimeBarTransform, newDaysCounter);
        }
    }

    public void SetUIElements(Transform newTimeBarTransform, TextMeshProUGUI newDaysCounter)
    {
        timeBarTransform = newTimeBarTransform;
        initialScale = timeBarTransform.localScale; // Update initial scale for new transform
        daysCounter = newDaysCounter;
        UpdateDaysCounter(); // Update the counter immediately with current values
    }

    void OnDestroy()
    {
        // Unsubscribe from the scene loaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    
}
