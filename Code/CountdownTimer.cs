using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float myTimer = 999f;
    public Text timerText;
    public GameObject Canvas;
    private bool timerIsActive = true;

    public static CountdownTimer instance;

    void Start()
    {

    }

    void Awake()
    {
        this.InstantiateTimer();
        //DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (timerIsActive)
        {
            myTimer -= Time.deltaTime;
            timerText.text = "Time: " + myTimer.ToString("F0");
        }
        if (myTimer <= 0f)
        {
            myTimer = 0f;
            timerIsActive = false;
        }
    }

    private void InstantiateTimer(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(Canvas.gameObject);
            DontDestroyOnLoad(this);
        }
        else if(this != instance){
            Destroy(Canvas.gameObject);
            Destroy(this.gameObject);
        }
    }
}