using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //public Transform[] target;
    public GameObject[] targets;
    public float speed;
    private int current;
    // Use this for initialization    
    void Start() { }
    // Update is called once per frame    
    void Update()
    {
        if (transform.position != targets[current].transform.position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, targets[current].transform.position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject == targets[current] )
        {
            current = (current + 1) % targets.Length;
        }
    }
}
