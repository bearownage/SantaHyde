using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset  = new Vector3(0,10,-15);
    
    

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
