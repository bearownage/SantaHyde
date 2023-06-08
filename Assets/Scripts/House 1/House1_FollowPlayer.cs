using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House1_FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset  = new Vector3(0,80,-50);
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Offset the camera position above the player
        transform.position = player.transform.position +  offset;
        
    }
}
