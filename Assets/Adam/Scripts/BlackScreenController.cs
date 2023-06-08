using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackScreenController : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI chargesText;

    private int numberOfCharges = 100;
    //public Image blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LightUpScreen());
        chargesText.text = "Number of light up charges left: " + numberOfCharges;
    }

    IEnumerator LightUpScreen()
    {
        if (Input.GetKeyDown("b") && numberOfCharges > 0)
        {
            Debug.Log("User pressed b");
            panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            instructionText.enabled = false;
            chargesText.enabled = false;
            yield return new WaitForSeconds(1);
            Debug.Log("Revert Screen");
            chargesText.enabled = true;
            panel.GetComponent<Image>().color = new Color(0, 0, 0, 255);
            numberOfCharges--;
            if ( numberOfCharges > 0 )
            {
                instructionText.enabled = true;
            }
        }
    }
}
