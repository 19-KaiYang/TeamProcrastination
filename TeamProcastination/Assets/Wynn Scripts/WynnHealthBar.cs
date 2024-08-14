using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WynnHealthBar : MonoBehaviour
{

    public WynnPlayerHealth health;
    public Image healthBarTransform; // This should be an Image component
    private Vector3 OriginalScale;

    void Start()
    {
        if (health != null)
        {
            health.onHealthChanged += UpdateHealthBar;
        }
        OriginalScale = healthBarTransform.rectTransform.localScale; // Use rectTransform for UI elements
    }

    void UpdateHealthBar(float currentHealth)
    {
        if (healthBarTransform == null)
            return;

        float healthPercentage = Mathf.Clamp01(currentHealth / health.maxHealth); // Clamp to ensure it's between 0 and 1

        // Update the scale based on the health percentage
        healthBarTransform.rectTransform.localScale = new Vector3(healthPercentage, 1f, 1f);
    }
}
