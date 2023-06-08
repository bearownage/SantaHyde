using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Scene management namespace
using UnityEngine.SceneManagement; 

public class RetryButton : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        // Reloads the current scene
        House1_Player.isSpotted = false;
        PresentController.PresentsCollected = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
