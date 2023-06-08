using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverButtonController : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Reload level
    public void OnClick()
    {
        if (House1_Player.isNight)
        {
            SwitchController.userActivatedSwitch = false;
            SceneManager.LoadScene("Scenes/House 1 Night");
        } 
        else
        {
            SceneManager.LoadScene("Scenes/House 1 Day");
        }

    }
}
