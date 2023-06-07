using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingEnemyController : MonoBehaviour
{
    public Vector3 destination;
    public Transform Player, Patrol;
    public NavMeshAgent agent;
    public GameObject cube;
    public bool spotted;
    public float searchTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( spotted == false )
        {
            destination = Patrol.position;
            agent.destination = destination;
        } 
        else
        {
            destination = Player.position;
            agent.destination = destination;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.name == "Player")
        {
            spotted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject.name == "Player")
        {
            StartCoroutine(search());
        }
    }

    IEnumerator search()
    {
        yield return new WaitForSeconds(searchTime);
        spotted = false;
    }
}
