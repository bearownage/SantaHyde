using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(3, 1, -1);
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientLight = Color.black;
        Light[] ligths = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light ligth in ligths)
        {
            ligth.enabled = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
    }
}

