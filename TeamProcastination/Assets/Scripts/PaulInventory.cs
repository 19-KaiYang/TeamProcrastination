using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaulInventory : MonoBehaviour
{
    public Image[] slots = new Image[2];
    public Sprite cornsprite;
    public Sprite turnipsprite;
    public TMP_Text[] itemAmountText = new TMP_Text[2];
    private int[] itemAmount = new int[2];
    

    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 0; i < slots.Length; i++)
        {
            // Getting image component of each slot
            slots[i].GetComponent<Image>();

            // Get the TextMeshProUGUI component
            itemAmountText[i].GetComponent<TMP_Text>();

            itemAmount[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
       

        // number input for testing adding of corn and turnip
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            AddCorn();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddTurnip();           
        }
    }

    public void CloseInventory()
    {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0f, -82.3f);
    }

    public void OpenInventory()
    {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0f, 204.0f);
    }

    // Method to add an item to the inventory
    public void AddCorn()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slots[i].sprite == null) // Check if slot is empty
            {
                slots[i].sprite = cornsprite;
                itemAmount[i] += 1;
                itemAmountText[i].text = itemAmount[i].ToString();
                // Assign the item's sprite to the slot
                break; // Exit loop after finding the first empty slot
            }


            if (slots[i].sprite == cornsprite)
            {
                itemAmount[i] += 1;
                itemAmountText[i].text = itemAmount[i].ToString();
                break;
            }
        }
    }


    // Method to add an item to the inventory
    public void AddTurnip()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slots[i].sprite == null) // Check if slot is empty
            {
                slots[i].sprite = turnipsprite;
                itemAmount[i] += 1;
                itemAmountText[i].text = itemAmount[i].ToString();
                // Assign the item's sprite to the slot
                break; // Exit loop after finding the first empty slot
            }

            if (slots[i].sprite == turnipsprite)
            {
                itemAmount[i] += 1;
                itemAmountText[i].text = itemAmount[i].ToString();
                break;
            }
        }
    }

}
