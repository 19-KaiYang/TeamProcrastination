using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ClefSeedSelection : MonoBehaviour
{
    // images of all the seeds
    public GameObject defaultSeed;
    public GameObject seed1;
    public GameObject seed2;
    public GameObject seed3;

    // texts of all the seeds
    public GameObject defaultSeedText;
    public GameObject seed1Text;
    public GameObject seed2Text;
    public GameObject seed3Text;

    // open and close seeds
    public bool seed1Selected = false;
    public bool seed2Selected = false;
    public bool seed3Selected = false;

    // Start is called before the first frame update
    void Start()
    {
        defaultSeed.SetActive(true); // start of shop, display "please select a seed"
        defaultSeedText.SetActive(true); // start of shop, display "???"
    }

    // Update is called once per frame
    void Update()
    {
        // corn
        if (seed1Selected == true) // if corn seed has been selected
        {
            defaultSeed.SetActive(false); // closes ???
            defaultSeedText.SetActive(false); // close the ??? text
            seed1.SetActive(true); // set corn seed to appear
            seed1Text.SetActive(true); // set corn text to appear
            seed2.SetActive(false); // close seed 2
            seed2Text.SetActive(false); // close seed 2 text
            seed3.SetActive(false); // close seed 3
            seed3Text.SetActive(false); // close seed 3 text

            
        }

        // turnip
        if (seed2Selected == true) // if turnip seed has been selected
        {
            defaultSeed.SetActive(false); // closes the ???
            defaultSeedText.SetActive(false); // close the ??? text
            seed1.SetActive(false); // close seed 1
            seed1Text.SetActive(false); // close seed 1 text
            seed2.SetActive(true); // set turnip seed to appear
            seed2Text.SetActive(true); // set turnip text to appear
            seed3.SetActive(false); // close seed 3
            seed3Text.SetActive(false); // close seed 3 text
        }

        // apple?
        if (seed3Selected == true) // if [random] seed has been selected
        {
            defaultSeed.SetActive(false); // closes the ??? seed when an actual one has been selected
            defaultSeedText.SetActive(false); // close the ??? text
            seed1.SetActive(false); // close seed 1
            seed1Text.SetActive(false); // close seed 1 text
            seed2.SetActive(false); // close seed 2
            seed2Text.SetActive(false); // close seed 2 text
            seed3.SetActive(true); // set [random] seed to appear
            seed3Text.SetActive(true); // set [random] text to appear
        }
    }
}
