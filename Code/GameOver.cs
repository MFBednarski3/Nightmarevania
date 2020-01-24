using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevel(5));
    }

    IEnumerator LoadLevel(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Title");
    }
}
