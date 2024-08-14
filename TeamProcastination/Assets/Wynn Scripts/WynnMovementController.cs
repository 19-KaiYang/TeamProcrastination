using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WynnMovementController : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb.velocity = Vector2.zero;
        rb.drag = 6f;
    }

    private void Update()
    {
        
    }

    public void Move(float dirH, float dirV, float walkSpeed)
    {
        // Create a direction vector based on horizontal and vertical inputs
        Vector2 movementDirection = new Vector2(dirH, dirV).normalized;

        // Apply force to the Rigidbody2D in the calculated direction
        rb.AddForce(movementDirection * walkSpeed);
    }

    public void KnockBack(Vector2 facingdir, float knockback)
    {
        if (rb != null)
        {
            rb.AddForce(facingdir * knockback, ForceMode2D.Impulse);
        }
    }
}
