using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftPlacement : MonoBehaviour
{
    public GameObject gift; // Assign the 'Gift' GameObject in the Inspector

    private void Start()
    {
        // Make the gift invisible at the start
        gift.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if(other.gameObject.name == "Player")
        {
            // Make the gift visible
            gift.SetActive(true);
        }
    }
}
