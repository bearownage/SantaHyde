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
    private float remainingTime = 60f;
    public GameObject panel;
    public GameObject timeUp;
    public GameObject retry;

    public void Start()
    {
        timeUp.SetActive(false);
        retry.SetActive(false);
    }

    private void Update()
    {
        

        if(remainingTime != 0)
        {
            
            StartCoroutine(LightUpScreen());
            remainingTime -= Time.deltaTime;
        
            if (remainingTime < 0)
                remainingTime = 0;

            chargesText.text = totalCharges.ToString();
            timeText.text = Mathf.Round(remainingTime).ToString();
        }
        else 
        {
            timeUp.SetActive(true);
            retry.SetActive(true);
        }
    }

    IEnumerator LightUpScreen()
    {
        if (Input.GetKeyDown("e") && totalCharges > 0)
        {
            Debug.Log("User pressed E to use a charge, charges left : "+totalCharges);
            panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            //instructionText.enabled = false;
            //chargesText.enabled = false;
            yield return new WaitForSeconds(1);
            Debug.Log("Revert Screen to Dark");
            //chargesText.enabled = true;
            panel.GetComponent<Image>().color = new Color(0, 0, 0, 255);
            totalCharges--;
        }
    }
}
