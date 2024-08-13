using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WynnAnimationController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void FlipSprite(bool flip)
    {
        // Flip the sprite based on direction
        spriteRenderer.flipX = flip; // Face right
    } 
}
