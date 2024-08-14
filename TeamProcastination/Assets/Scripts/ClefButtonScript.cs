using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClefButtonScript : MonoBehaviour
{
    public TMP_Text quantityText;
    public GameObject yourBroke;
    private int itemQuantity = 0;
    public TMP_Text walletText;
    public float wallet = 1000f; 

    public void OnAddClick()
    {
        itemQuantity++;
        UpdateQuantityText();
    }

    public void OnSubtractClick()
    {
        if (itemQuantity > 0)
        {
            itemQuantity--;
        }
        UpdateQuantityText();
    }

    private void UpdateQuantityText()
    {
        quantityText.text = "Quantity: " + itemQuantity.ToString();

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
        itemQuantity = 0;
        UpdateQuantityText();
    }

    // Update is called once per frame
    void Update()
    {
        walletText.text = "Your Wallet: $" + wallet.ToString(); 
        
        
    }
}
