using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ClefButtonScript : MonoBehaviour
{
    // text display
    public TMP_Text quantityText; // amount of item to buy
    public TMP_Text walletText; // money amount
    
    // for setactive purposes
    public GameObject yourBroke; // broke
    public GameObject noMoneyText; // not enough money
    public GameObject productwhere; // no product selected

    // numbers
    private int itemQuantity = 0;
    public float wallet = 1000f;
    private float seed1Cost = 100f; // Cost of each seed1
    private float seed2Cost = 50f; // Cost of each seed2
    private float seed3Cost = 20f; // Cost of each seed3

    // use selection class
    public ClefSeedSelection clefSeedSelection;

    // add button for quantity
    public void OnAddClick()
    {
        itemQuantity++;
        UpdateQuantityText();
    }

    // subtract button for quantity
    public void OnSubtractClick()
    {
        // if quantity is more than 0 then it will start subtracting, else it wont go below 0
        if (itemQuantity > 0)
        {
            itemQuantity--;
        }
        UpdateQuantityText(); // update count
    }

    private void UpdateQuantityText()
    {
        quantityText.text = "Quantity: " + itemQuantity.ToString();

    }

    public void OnPurchaseClick()
    {
        if (clefSeedSelection.seed1Selected == true)
        {
            float totalCost1 = itemQuantity * seed1Cost; // total cost of product = amount of product * the cost of seed1

            // if total cost of product is more than wallet amount
            if (totalCost1 > wallet)
            {
                noMoneyText.SetActive(true); // Display "NO MONEY" if the cost exceeds wallet
                StartCoroutine(HideTextAfterDelay(noMoneyText, 2.0f)); // Hide after 2 seconds
            }
            else
            {
                wallet -= totalCost1; // Deduct the cost from the wallet
                walletText.text = "Your Wallet: $" + wallet.ToString();
                noMoneyText.SetActive(false); // Hide "NO MONEY" text if purchase is successful
            }

            if (wallet <= 0f)
            {
                yourBroke.SetActive(true); // Display "Your Broke" text if the wallet is empty
                StartCoroutine(HideTextAfterDelay(yourBroke, 2.0f)); // Hide after 2 seconds
            }

        }

        else if (clefSeedSelection.seed2Selected == true)
        {
            float totalCost2 = itemQuantity * seed2Cost; // total cost of product = amount of product * the cost of seed1

            // if total cost of product is more than wallet amount
            if (totalCost2 > wallet)
            {
                noMoneyText.SetActive(true); // Display "NO MONEY" if the cost exceeds wallet
                StartCoroutine(HideTextAfterDelay(noMoneyText, 2.0f)); // Hide after 2 seconds
            }
            else
            {
                wallet -= totalCost2; // Deduct the cost from the wallet
                walletText.text = "Your Wallet: $" + wallet.ToString();
                noMoneyText.SetActive(false); // Hide "NO MONEY" text if purchase is successful
            }

            if (wallet <= 0f)
            {
                yourBroke.SetActive(true); // Display "Your Broke" text if the wallet is empty
                StartCoroutine(HideTextAfterDelay(yourBroke, 2.0f)); // Hide after 2 seconds
            }

        }

        else if (clefSeedSelection.seed3Selected == true)
        {
            float totalCost3 = itemQuantity * seed3Cost; // total cost of product = amount of product * the cost of seed1

            // if total cost of product is more than wallet amount
            if (totalCost3 > wallet)
            {
                noMoneyText.SetActive(true); // Display "NO MONEY" if the cost exceeds wallet
                StartCoroutine(HideTextAfterDelay(noMoneyText, 2.0f)); // Hide after 2 seconds
            }
            else
            {
                wallet -= totalCost3; // Deduct the cost from the wallet
                walletText.text = "Your Wallet: $" + wallet.ToString();
                noMoneyText.SetActive(false); // Hide "NO MONEY" text if purchase is successful
            }

            if (wallet <= 0f)
            {
                yourBroke.SetActive(true); // Display "Your Broke" text if the wallet is empty
                StartCoroutine(HideTextAfterDelay(yourBroke, 2.0f)); // Hide after 2 seconds
            }

        }

        else
        {
            productwhere.SetActive(true); // display no product selected
            StartCoroutine(HideTextAfterDelay(productwhere, 2.0f)); // Hide after 2 seconds
        }
    }

    // timer for display texts to hide
    private IEnumerator HideTextAfterDelay(GameObject textObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        textObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        itemQuantity = 0;
        UpdateQuantityText(); 
        noMoneyText.SetActive(false);
        productwhere.SetActive(false);
        yourBroke.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // update wallet
        walletText.text = "Your Wallet: $" + wallet.ToString();

        

    }
}
