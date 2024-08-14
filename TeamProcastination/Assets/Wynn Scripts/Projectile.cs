using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private float explosionForce = 10.0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var zEulerAngle = Mathf.Atan2(rigidBody.velocity.y, rigidBody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zEulerAngle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Vector2 bulletDirection = transform.right; // Right represents the forward direction for 2D
            Rigidbody2D projectileRigidBody = rigidBody.GetComponent<Rigidbody2D>();

            if (projectileRigidBody != null)
            {
                projectileRigidBody.AddForce(bulletDirection * explosionForce, ForceMode2D.Impulse);
            }

            Destroy(gameObject);
        }
    }
}
