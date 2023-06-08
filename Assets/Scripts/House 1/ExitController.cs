using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public GameObject warningMessage;
    public Night_GameUIManager night_GameUIManager;

    // Start is called before the first frame update
    void Start()
    {
        warningMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Exit Controller");
        //Debug.Log("Presents collected: " + PresentController.PresentsCollected);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log("Exit collission!");
        if ( collision.gameObject.name == "Player" )
        {
            Debug.Log("Presents collected as shown in Exit Controller: " + PresentController.PresentsCollected);
            if (PresentController.PresentsCollected == 1 && night_GameUIManager.remainingTime != 0)
            {
                SceneManager.LoadScene("Lvl 1 Complete");
            } 
            else
            {
                warningMessage.SetActive(true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        warningMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!?!?!");
    }
}
