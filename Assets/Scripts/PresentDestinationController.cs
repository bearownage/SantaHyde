using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresentDestinationController : MonoBehaviour
{
    public GameObject choseOptionMessage;
    public GameObject labelText;
    public GameObject sugarCookies;
    public GameObject caffeineCookies;

    private bool hasChosenAPresent = false;
    // Start is called before the first frame update
    void Start()
    {
        choseOptionMessage.SetActive(false);
        sugarCookies.SetActive(false);
        caffeineCookies.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasChosenAPresent)
        {
            labelText.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.name == "Player")
            {
                if (!hasChosenAPresent)
                {
                    choseOptionMessage.SetActive(true);
                }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (!hasChosenAPresent)
        {
            if (Input.GetKeyDown("1"))
            {
                Debug.Log("User pressed 1");
                hasChosenAPresent = true;
                caffeineCookies.SetActive(true);
            }
            else if (Input.GetKeyDown("2"))
            {
                Debug.Log("User Pressed 2");
                hasChosenAPresent = true;
                sugarCookies.SetActive(true);
            }
            else
            {
                Debug.Log("Ignore input");
            }
        }

        if ( hasChosenAPresent )
        {
            choseOptionMessage.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        choseOptionMessage.SetActive(false);
    }
}
