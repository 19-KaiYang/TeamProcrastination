using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float walkSpeed = 10f;
    [SerializeField] private float damage = 10f;

    public Rigidbody2D player;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 5f;
    }

    void Update()
    {
        CheckTargetDirection();
    }

    void FixedUpdate()
    {
        if (player == null)
            return;

        // Calculate the direction vector from the enemy to the player
        Vector2 direction = (player.position - rb.position).normalized;

        // Apply force to the enemy in the direction of the player
        rb.AddForce(direction * walkSpeed);
    }

    void CheckTargetDirection()
    {
        if (player == null)
            return;

        // Calculate the difference in the x-coordinate between the target and the enemy
        float directionToTarget = player.position.x - transform.position.x;

        //Right
        if (directionToTarget > 0)
        {
            spriteRenderer.flipX = false;
        }
        //Left
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the EnemyScript component from the collided object
            WynnMovementController playerScript = collision.gameObject.GetComponent<WynnMovementController>();
            WynnPlayerHealth playerHealth = collision.gameObject.GetComponent<WynnPlayerHealth>();

            if (playerScript != null)
            {
                Vector2 directionToPlayer = (collision.transform.position - transform.position).normalized;

                playerScript.KnockBack(directionToPlayer, 5); // Pass the direction and force magnitude

                playerHealth.TakeDamage(damage);
            }
        }
    }
}
