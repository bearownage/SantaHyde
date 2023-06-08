using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Add this line

public class Day_GameUIManager : MonoBehaviour
{
    //public TextMeshProUGUI chargesText; // Update this line
    public TextMeshProUGUI timeText; // And this line
    //public int totalCharges = 3;
    private float remainingTime = 60f;
    public GameObject panel;
    public GameObject spotted;
    public GameObject timeUp;
    public GameObject retry;

    public GiftPlacement giftPlacementScript; // Reference to the GiftPlacement script. Assign in the Inspector.
    

    public void Start()
    {
        timeUp.SetActive(false);
        retry.SetActive(false);
        spotted.SetActive(false);
    }

    private void Update()
    {
        if (House1_Player.isSpotted)
        {
            spotted.SetActive(true);
            retry.SetActive(true);
        }
        

        if(remainingTime != 0)
        {
            remainingTime -= Time.deltaTime;
        
            if (remainingTime < 0)
                remainingTime = 0;

            //chargesText.text = totalCharges.ToString();
            timeText.text = Mathf.Round(remainingTime).ToString();
        }
        else if (remainingTime == 0 && giftPlacementScript.giftPlaced && House1_Player.isSpotted == false) // If time is up and the gift has been placed
        {
            // Load the next scene
            SceneManager.LoadScene("House 1 Night");
        }
        else
        {
            timeUp.SetActive(true);
            retry.SetActive(true);
            
        }
        
    }

    
}
