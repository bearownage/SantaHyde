using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1Complete : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("World");
    }
}
