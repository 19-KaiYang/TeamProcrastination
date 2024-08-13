using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClefHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject imageHighlight;

    void Start()
    {
        imageHighlight.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageHighlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageHighlight.SetActive(false);
    }
}
