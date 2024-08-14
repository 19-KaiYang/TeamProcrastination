using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WynnPlayerHealth : MonoBehaviour
{
     public float maxHealth = 100f;
    public float currentHealth;

    public delegate void OnHealthChanged(float health);
    public event OnHealthChanged onHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " took damage: " + amount + ", current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

        onHealthChanged?.Invoke(currentHealth);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log(gameObject.name + " healed: " + amount + ", current health: " + currentHealth);
        onHealthChanged?.Invoke(currentHealth);
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died.");
        // Handle the death of the enemy or player
        Destroy(gameObject);
    }
}
