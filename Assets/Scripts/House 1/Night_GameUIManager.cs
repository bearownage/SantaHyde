using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // Add this line

public class Night_GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI chargesText; // Update this line
    public TextMeshProUGUI timeText; // And this line
    public int totalCharges = 3;
    public float remainingTime = 30f;
    public GameObject panel;
    public GameObject timeUp;
    public GameObject retry;
    public GameObject spotted;

    public GameObject present;
    public GameObject presentCollectedText;
    private bool presentTextHasBeenDisplayed = false;

    public SwitchController switchController;

    private bool hasDecidedToActiveSwitch;

    public void Start()
    {
        timeText.enabled = false;

        timeUp.SetActive(false);
        retry.SetActive(false);
        spotted.SetActive(false);
        presentCollectedText.SetActive(false);
    }

    private void Update()
    {
        // If player is spotted
        if (House1_Player.isSpotted)
        {
            spotted.SetActive(true);
            retry.SetActive(true);
        }

        //If player collects the present
        if ( PresentController.PresentsCollected == 1 && presentTextHasBeenDisplayed != true)
        {
            StartCoroutine(DisplayPresentCollectedText());
        }

        if (remainingTime != 0)
        {
            StartCoroutine(LightUpScreen());
            chargesText.text = totalCharges.ToString();

            if (hasDecidedToActiveSwitch)
            {
                timeText.enabled = true;
                remainingTime -= Time.deltaTime;

                if (remainingTime < 0)
                    remainingTime = 0;

                timeText.text = Mathf.Round(remainingTime).ToString();
            }
        }
        else 
        {
            timeUp.SetActive(true);
            retry.SetActive(true);
        }
    }

    IEnumerator LightUpScreen()
    {
        // Determine how long to light up the screen for
        float seconds;
        if (switchController.wantToActivateSwitchText.activeSelf)
        {
            seconds = 5;
        } 
        else
        {
            seconds = 1;
        }
        if (Input.GetKeyDown("e"))
        {
            if (seconds == 5 && hasDecidedToActiveSwitch)
            {
                // User has already activated switch, ignore
                yield return new WaitForSeconds(0);
            } else if (seconds == 1 && totalCharges <= 0) {
                // User has used up all charges, ignore
                yield return new WaitForSeconds(0);
            }

            // Account for use;
            if ( seconds == 5 )
            {
                hasDecidedToActiveSwitch = true;
            } else
            {
                totalCharges--;
            }

            Debug.Log("User pressed E to use a charge, charges left : "+totalCharges);
            panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(seconds);
            Debug.Log("Revert Screen to Dark");
            panel.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
    }

    IEnumerator DisplayPresentCollectedText()
    {
        presentCollectedText.SetActive(true);
        yield return new WaitForSeconds(1);
        presentCollectedText.SetActive(false);
        presentTextHasBeenDisplayed = true;
    }
}
