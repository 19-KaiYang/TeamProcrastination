using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClefShopScript : MonoBehaviour
{
    private Image productImage;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Set this to whatever color you want for highlighting.
    private Vector3 originalScale;

    void Start()
    {
        productImage = GetComponent<Image>();
        originalColor = productImage.color; // Store the original color of the image.
        originalScale = transform.localScale; // stores the original scale
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Entered");
        HighlightImage();
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exited");
        RemoveHighlight();
    }

    void HighlightImage()
    {
        // Change the color of the image to the highlight color
        productImage.color = highlightColor;

        // increase the scale slightly
        transform.localScale = originalScale * 1.1f;
    }

    void RemoveHighlight()
    {
        // Revert the image color back to the original color
        productImage.color = originalColor;

        // revert to the original scale
        transform.localScale = originalScale;
    }
}
