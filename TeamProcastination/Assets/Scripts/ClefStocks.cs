using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClefStocks : MonoBehaviour
{
    public ClefSeedSelection clefSeedSelection;

    public void OnSeed1Click()
    {
        clefSeedSelection.seed1Selected = true;
        clefSeedSelection.seed2Selected = false;
        clefSeedSelection.seed3Selected = false;
    }

    public void OnSeed2Click()
    {
        clefSeedSelection.seed1Selected = false;
        clefSeedSelection.seed2Selected = true;
        clefSeedSelection.seed3Selected = false;
    }

    public void OnSeed3Click()
    {
        clefSeedSelection.seed1Selected = false;
        clefSeedSelection.seed2Selected = false;
        clefSeedSelection.seed3Selected = true;
    }


}
