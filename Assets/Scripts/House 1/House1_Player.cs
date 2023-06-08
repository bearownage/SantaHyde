using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//for scene change
using UnityEngine.SceneManagement;

public class House1_Player : MonoBehaviour
{
    private float speed = 6.0f;
    private bool hasKey = false; // to track if key is collected
    private bool isNearPostbox = false;
    public GameObject imageObject; // The GameObject of the Image
    public TextMeshProUGUI spottedText;
    public GameObject screen;
    //public GameObject EnterPopUp;

    private void Start()
    {
        spottedText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.position += movement * speed * Time.deltaTime;

         // Check for 'E' key press
        if (Input.GetKeyDown(KeyCode.E) && isNearPostbox)
        {
            // Switch to 'House 1' scene
            SceneManager.LoadScene("House 1");
        }
    }

    //
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Debug.Log("Collided with enemy");
            StartCoroutine(spottedThenEndGame());
        }
    }

    IEnumerator spottedThenEndGame()
    {
        Debug.Log("Player spotted, end the game");
        spottedText.enabled = true;
        screen.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Adam/Scenes/BasedGameOverScene");
    }

    // This function is called when this object collides with another object
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the Key
        if (other.gameObject.name == "Key")
        {
            hasKey = true; // set the flag
            other.gameObject.SetActive(false); // make the Key gameobject not visible
        }
        // Check if the player collided with the Locked Door
        else if (other.gameObject.name == "Locked Door" && hasKey)
        {
            Destroy(other.gameObject); // remove the Locked Door gameobject from the game
        }

        // If the player has entered the postbox trigger
        if (other.gameObject.name == "Postbox 1")
        {
            // Show the image
            imageObject.SetActive(true);
            isNearPostbox = true;
            
        }

    }

    void OnTriggerExit(Collider other)
    {
        // If the player has exited the postbox trigger
        if (other.gameObject.name == "Postbox 1")
        {
            // Hide the image
            imageObject.SetActive(false);
            isNearPostbox = false;
        }
    }
}