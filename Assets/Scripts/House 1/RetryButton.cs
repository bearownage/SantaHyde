using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Scene management namespace
using UnityEngine.SceneManagement; 

public class RetryButton : MonoBehaviour
{

    public GiftPlacement giftPlacement;
    public void OnRetryButtonClicked()
    {
        // Should only happen during day.
        if ( giftPlacement != null )
        {
            giftPlacement.giftPlaced = false;
        }
        // Reloads the current scene
        House1_Player.isSpotted = false;
        PresentController.PresentsCollected = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
