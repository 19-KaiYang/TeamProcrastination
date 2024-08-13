using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClefButtonScript : MonoBehaviour
{
    public GameObject quantityText;
    public GameObject yourBroke;
    private float itemQuantity;
    public float wallet = 0f; 

    public void OnAddClick()
    {
        itemQuantity++;
    }

    public void OnSubtractClick()
    {
        if (itemQuantity <= 0f)
        {
            itemQuantity = 0f;
        }
        else
        {
            itemQuantity--;
        }

        
    }

    public void OnPurchaseClick()
    {
        if (wallet <= 0f)
        {
            yourBroke.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        itemQuantity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        

        
        
    }
}
