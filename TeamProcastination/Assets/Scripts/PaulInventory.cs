using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaulInventory : MonoBehaviour
{
    public Image[] slots = new Image[2];
    public GameObject[] Highlight = new GameObject[2];
    public TMP_Text[] itemAmountText = new TMP_Text[2];
    private int[] itemAmount = new int[2];
    public Button[] slotButtons = new Button[2];
    public Sprite cornseedSprite;
    public Sprite turnipseedSprite;
    public bool[] SlotSelected = new bool[2];


    // Start is called before the first frame update
    void Start()
    {

        foreach (Button button in slotButtons)
        {
            button.onClick.AddListener(() => ButtonSelect(button));
        }

        for (int i = 0; i < slots.Length; i++)
        {
            // Getting image component of each slot
            slots[i].GetComponent<Image>();

            Highlight[i].GetComponent<GameObject>();
            
            // Get the TextMeshProUGUI component
            itemAmountText[i].GetComponent<TMP_Text>();

            // Disabling highlight selector of all slots (highlight enables when a slot is selected upon click to show that a slot is selected)
            Highlight[i].SetActive(false);

            // Set itemamount for all slots to 0 and slotselection for all slots to false
            itemAmount[i] = 0;
            SlotSelected[i] = false;

            // Amount text set to nothing at first
            itemAmountText[i].text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
       

        // number input for testing adding of corn and turnip
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            AddCornSeed();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddTurnipSeed();           
        }

       
        // Key to remove itemAmount in selected slot, and if itemAmount is 0 the object icon is removed from the slot
        if (Input.GetKeyDown(KeyCode.G))
        {
            RemoveObjectFromSlot();
        }
        
    }

    // Close the Inventory Button Method
    public void CloseInventory()
    {
        RectTransform InventoryPosition = this.GetComponent<RectTransform>();
        InventoryPosition.anchoredPosition = new Vector2(0f, -82.3f);
    }

    // Open the Inventory Button Method
    public void OpenInventory()
    {
        RectTransform InventoryPosition = this.GetComponent<RectTransform>();
        InventoryPosition.anchoredPosition = new Vector2(0f, 204.0f);
    }

    // Method to add corn to the inventory
    public void AddCornSeed()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slots[i].sprite == null) // Check if slot is empty
            {
                // set the slot's sprite to corn sprite
                slots[i].sprite = cornseedSprite;
                // Increment the corn amount
                itemAmount[i] += 1;
                // Visually display the corn amount in TMP text
                itemAmountText[i].text = itemAmount[i].ToString();
                // Set the slots tag to corn seed
                slots[i].tag = "CornSeed";
              
                break; // Exit loop after finding the first empty slot
            }

            // if same slot has corn, increment corn amount in that slot
            if (slots[i].sprite == cornseedSprite)
            {
                itemAmount[i] += 1;
                itemAmountText[i].text = itemAmount[i].ToString();
                break;
            }
        }
    }


    // Method to add turnip to the inventory
    public void AddTurnipSeed()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slots[i].sprite == null) // Check if slot is empty
            {
                // set the slot's sprite to turnip sprite
                slots[i].sprite = turnipseedSprite;
                // Increment the turnip amount
                itemAmount[i] += 1;
                // Visually display the turnip amount in TMP text
                itemAmountText[i].text = itemAmount[i].ToString();
                // Set the slots tag to Turnip
                slots[i].tag = "TurnipSeed";
                break; // Exit loop after finding the first empty slot
            }

            // if same slot has turnip, increment turnip amount in that slot
            if (slots[i].sprite == turnipseedSprite)
            {
                itemAmount[i] += 1;
                itemAmountText[i].text = itemAmount[i].ToString();
                break;
            }
        }
    }

    // To remove an a selected object
    public void RemoveObjectFromSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (SlotSelected[i] == true)
            {
                // Remove item from the selected object if its more than 0
                if (itemAmount[i] > 0)
                {
                    itemAmount[i]--;
                    itemAmountText[i].text = itemAmount[i].ToString();
                }

                // if itemamount is 0               
                if (itemAmount[i] == 0)
                {
                    slots[i].sprite = null; // Set the sprite to null to show the slot is "removed"
                    itemAmountText[i].text = ""; // clear the text of the deleted slot
                    slots[i].tag = "Untagged"; // Set tag to Untagged
                    SlotSelected[i] = false; // slot is unselected
                    Highlight[i].SetActive(false); // set the highlight to false as slot is unselected

                    // Shift the slots
                    for (int j = i; j < slots.Length - 1; j++)
                    {
                        if (itemAmount[j + 1] > 0)
                        {
                            // Move the next slot data to the current slot
                            itemAmount[j] = itemAmount[j + 1];
                            itemAmountText[j].text = itemAmount[j] > 0 ? itemAmount[j].ToString() : "";
                            slots[j].sprite = slots[j + 1].sprite;
                            slots[j].tag = slots[j + 1].tag;
                            
                        }
                        else
                        {
                            // if next slot is empty, break the loop to preven unecessary slot moving
                            break;
                        }
                    }

                    // clear the last slot 
                    slots[slots.Length - 1].sprite = null;
                    itemAmount[slots.Length - 1] = 0;
                    itemAmountText[slots.Length - 1].text = "";
                    slots[slots.Length - 1].tag = "Untagged";

                }
                

            }
        }
    }

    // Function for handling all button click events in the inventory except for the open and close inventory buttons
    public void ButtonSelect(Button button)
    {
        // Deactivate all existing highlights first
        for (int i = 0; i < Highlight.Length; i++)
        {
            Highlight[i].SetActive(false);
            SlotSelected[i] = false;
        }

        // Afterwards, set highlight for most recently pressed button
        for (int i = 0; i < slots.Length; i++)
        {
            if (button == slotButtons[i])
            {
                Highlight[i].SetActive(true);
                SlotSelected[i] = true;
            }
        }
    }


    

}
