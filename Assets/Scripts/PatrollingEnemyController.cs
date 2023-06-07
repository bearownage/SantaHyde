using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class PatrollingEnemyController : MonoBehaviour
{
    public Vector3 destination;
    public Transform Player, Patrol;
    public NavMeshAgent agent;
    public TextMeshProUGUI spottedText;
    public bool spotted;
    // Start is called before the first frame update
    void Start()
    {
        spottedText.enabled = false;
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
        Debug.Log("Enemy triggered by something!");
        if ( other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(spottedThenEndGame());
            spotted = true;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(search());
        }
    }*/

    IEnumerator spottedThenEndGame()
    {
        Debug.Log("Player spotted, end the game");
        spottedText.enabled = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scenes/BasedGameOverScene");
    }
}
