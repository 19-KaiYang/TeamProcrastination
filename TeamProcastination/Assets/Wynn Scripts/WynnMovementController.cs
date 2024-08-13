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
    }

    private void Update()
    {
        
    }

    public void Move(float dirH, float dirV, float walkSpeed)
    {
        Vector2 targetPosition = rb.position + new Vector2(dirH * walkSpeed, dirV * walkSpeed) * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }
}
