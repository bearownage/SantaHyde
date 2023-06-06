using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for scene change
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float rotationSpeed = 100.0F;
    public float jumpHeight = 2.0f;
    public float gravity = 9.8f;
    public float crouchHeight = 0.5f;
    
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private float originalHeight;

    // Make sure to assign these in the Inspector
    public GameObject imageObject; // The GameObject of the Image
    private bool isNearPostbox = false;

    public GameObject EnterPopUp;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Apply rotation
        Vector3 rotation = new Vector3(0, horizontal, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

        // Forward movement is based on vertical input
        Vector3 movement = new Vector3(0, 0, vertical);
        movement = transform.TransformDirection(movement);
        
        // Apply speed to movement
        movement *= speed;

        // Apply jump to movement
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }

        // Apply gravity to movement
        moveDirection.y -= gravity * Time.deltaTime;

        // Apply crouch to controller
        if (Input.GetKey(KeyCode.C))
        {
            controller.height = crouchHeight;
        }
        else
        {
            controller.height = originalHeight;
        }

        // Move the controller
        controller.Move((movement + moveDirection) * Time.deltaTime);


        // Check for 'E' key press
        if (Input.GetKeyDown(KeyCode.E) && isNearPostbox)
        {
            // Switch to 'House 1' scene
            SceneManager.LoadScene("House 1");
        }
    }

    void OnTriggerEnter(Collider other)
    {
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

    /*void OnCollisionEnter( Collision collision)
    { if (collision.gameObject.tag != "Postbox 1")
        return;

        // Rotate the object so that the y-axis faces along the normal of the surface
        ContactPoint contact = collision.contacts[0];
        Quaternion   rot     = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3      pos     = contact.point;
        Instantiate(EnterPopUp, pos, rot);
        
    }*/
}
