using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WynnCameraController : MonoBehaviour
{
    public Transform target;        // The target object to follow (e.g., the player)
    public float smoothTime = 0.3f; // The time it takes to smooth out the camera's movement
    public Vector2 minPosition;     // Minimum camera position (clamp bounds)
    public Vector2 maxPosition;     // Maximum camera position (clamp bounds)

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (target != null)
        {
            // Get the target position with z-axis being the current camera z position
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Clamp the target position to stay within bounds
            targetPosition = new Vector3(
                Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y),
                targetPosition.z
            );

            // Smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
