using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresentController : MonoBehaviour
{
    public static int PresentsCollected = 0;
    
    // public GameObject present;
    // Start is called before the first frame update
    void Start()
    {
        //presentCollectedMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Present Controller");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("On Collision Enter: Collision Happening");
        if (collision.gameObject.name == "Player")
        {
            PresentsCollected++;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }

    /*
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision Happening");
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }
    */
}
