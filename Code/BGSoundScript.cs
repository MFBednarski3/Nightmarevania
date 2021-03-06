﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private static BGSoundScript instance = null;
    public static BGSoundScript Instance{
        get{
            return instance;
        }
    }

    void Awake(){
        if (instance!=null && instance != this){
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Final" || SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
