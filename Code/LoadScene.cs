using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad1;
    public string sceneToLoad2;
    public string sceneToLoad3;
    public bool useQ = false;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadSceneOnClick1()
    {
        //switch scenes
        SceneManager.LoadScene(sceneToLoad1);

    }

    public void LoadSceneOnClick2()
    {
        //switch scenes
        SceneManager.LoadScene(sceneToLoad2);

    }

    public void LoadSceneOnClick3()
    {
        //switch scenes
        SceneManager.LoadScene(sceneToLoad3);

    }


    public void QuitGame(){
        Application.Quit();
    }


    void Update()
    {
        if (useQ == true && Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }

    }

}
