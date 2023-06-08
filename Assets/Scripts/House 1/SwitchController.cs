using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{

    public static bool userActivatedSwitch = false;
    public GameObject screen;

    public GameObject wantToActivateSwitchText;

    // Start is called before the first frame update
    void Start()
    {
        wantToActivateSwitchText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (!userActivatedSwitch)
        {
            if (other.gameObject.name == "Player")
            {
                wantToActivateSwitchText.SetActive(true);
                /*if (Input.GetKeyDown("e"))
                {
                    Debug.Log("User pressed e");
                    userActivatedSwitch = true;
                    wantToActivateSwitchText.enabled = false;
                    StartCoroutine(LightUpScreen());
                }
                else
                {
                    // Ignore
                }*/
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wantToActivateSwitchText.SetActive(false);
    }

    /*IEnumerator LightUpScreen()
    {
            screen.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            instructionText.enabled = false;
            chargesText.enabled = false;
            yield return new WaitForSeconds(5);
            Debug.Log("Revert Screen");
            instructionText.enabled = true;
            chargesText.enabled = true;
            screen.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
    }*/
}
