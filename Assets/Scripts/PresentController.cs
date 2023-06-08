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
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Present collected by player");
            PresentsCollected++;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }
}
