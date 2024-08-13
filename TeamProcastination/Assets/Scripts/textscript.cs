using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class textscript : MonoBehaviour
{
    public TMP_Text TMP_Text;
    public int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Player Score", 0);  // Default to 0 if no score is saved
        Debug.Log("Loaded Score: " + highscore);
    }

    // Update is called once per frame
    void Update()
    {
        TMP_Text.text ="Player Score: " + highscore.ToString();
        highscore += 1;

        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("Player Score", highscore);
            PlayerPrefs.Save();
            SceneManager.LoadScene("SampleScene");
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.SetInt("Player Score", highscore);
            PlayerPrefs.Save();
            SceneManager.LoadScene("KYTestScene");
        }


        if(Input.GetKeyDown(KeyCode.R))
        {
            highscore = 0;
        }

    }
}
