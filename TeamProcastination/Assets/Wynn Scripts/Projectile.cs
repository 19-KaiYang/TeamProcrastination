using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float explosionRadius = 1.0f;
    [SerializeField]
    float explosionForce = 10.0f;

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
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius: explosionRadius);

            foreach (Collider2D collider in colliders)
            {
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    Vector2 direction = (collider.transform.position - transform.position).normalized;
                    rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
                }
            }

            Destroy(gameObject);
        }
    }
}
