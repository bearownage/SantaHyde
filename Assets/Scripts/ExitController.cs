using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{

    [SerializeField] private List<Scene> _sceneList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Exit Controller");
        //Debug.Log("Presents collected: " + PresentController.PresentsCollected);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Exit collission!");
        if ( collision.gameObject.name == "Player" )
        {
            GameObject present = GameObject.Find("Present");
            PresentController presentController = present.GetComponent<PresentController>();
            Debug.Log("Presents collected as shown in Exit Controller: " + PresentController.PresentsCollected);

            if (PresentController.PresentsCollected == 1)
            {
                SceneManager.LoadScene("Scenes/WinScene");
                //_Win
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Exit Trigger!");
    }
}
