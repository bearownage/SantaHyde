using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftPlacement : MonoBehaviour
{
    public GameObject gift; // Assign the 'Gift' GameObject in the Inspector
    public bool giftPlaced { get; private set; } // Make it a property with a public getter and a private setter

    private void Start()
    {
        // Make the gift invisible at the start
        gift.SetActive(false);
        giftPlaced = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if(other.gameObject.name == "Player")
        {
            // Make the gift visible
            gift.SetActive(true);
            giftPlaced = true; // Set giftPlaced to true when the gift is placed
        }
    }
}
