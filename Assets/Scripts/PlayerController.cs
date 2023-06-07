using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 2.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    public GameObject presentCollectedMessage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the car forward based on vertical input
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
        // Rotates the car based on horizontal input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PresentCube")
        {
            StartCoroutine(DisplayPresentCollectedMessage());
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }

    IEnumerator DisplayPresentCollectedMessage()
    {
        presentCollectedMessage.SetActive(true);
        yield return new WaitForSeconds(1);
        Debug.Log("Set back to false now");
        presentCollectedMessage.SetActive(false);
    }
}
