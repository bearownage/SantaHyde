using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{

    public float timeValue = 30;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( SwitchController.userActivatedSwitch )
        {
            timeText.enabled = true;
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("Adam/Scenes/BasedGameOverScene");
            }

            DisplayTime(timeValue);
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if ( timeToDisplay < 0 )
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("Time remaining\n{0:00}:{1:00}", minutes, seconds);

        if ( timeToDisplay < 10 )
        {
            timeText.color = Color.red;
        }
    }
}
