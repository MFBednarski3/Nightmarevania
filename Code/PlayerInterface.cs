using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerInterface : MonoBehaviour
{

    static int keyCount = 0;


    public Text keyText;
    public Text scoreText;
    public Text timerText;


    static bool blueKeyGot = false;
    static bool purpleKeyGot = false;
    static bool yellowKeyGot = false;
    static bool orangeKeyGot = false;
    static bool redKeyGot = false;
    static bool greenKeyGot = false;

    static int score = 0;
    int highScore;
    static float myTimer = 600f;


    public AudioSource coinCollect;
    public AudioSource keyCollect;
    public AudioSource MoreHealth;
    public AudioSource damage;

    private bool timerIsActive = true;

    public SimpleHealthBar healthBar;
    static int health = 100;

    int finalScore;

    public InputField playerName;
    public Text myFinalScore;

    public Text scoreIsReset;
    public Button enterScore;

    static bool newgame = true;


    void Awake()
    {
        if (newgame == true){
            ResetGame();
            newgame = false;
        }
        if (SceneManager.GetActiveScene().name == "Final"){
            newgame = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            EndGameWin();
        }
        else{
            scoreText.text = "Score: " + score.ToString();
            healthBar.UpdateBar(health, 100);
            keyCheck();
        }

    }


    void Start()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Blue Key"){
             blueKeyGot = true;
                keyCount = keyCount + 1;
                Destroy(col.gameObject);
            keyCollect.Play();
            keyCheck();
            score = score + 1000;
            scoreText.text = "Score: " + score.ToString();
        }
        if (col.gameObject.name == "Purple Key"){
            purpleKeyGot = true;
            keyCount = keyCount + 1;
            Destroy(col.gameObject);
            keyCollect.Play();
            keyCheck();
            score = score + 1000;
            scoreText.text = "Score: " + score.ToString();
        }
        if (col.gameObject.name == "Yellow Key"){
            yellowKeyGot = true;
            keyCount = keyCount + 1;
            Destroy(col.gameObject);
            keyCollect.Play();
            keyCheck();
            score = score + 1000;
            scoreText.text = "Score: " + score.ToString();
        }
        if (col.gameObject.name == "Orange Key")
        {
            orangeKeyGot = true;
            keyCount = keyCount + 1;
            Destroy(col.gameObject);
            keyCollect.Play();
            keyCheck();
            score = score + 1000;
            scoreText.text = "Score: " + score.ToString();
        }
        if (col.gameObject.name == "Red Key")
        {
            redKeyGot = true;
            keyCount = keyCount + 1;
            Destroy(col.gameObject);
            keyCollect.Play();
            keyCheck();
            score = score + 1000;
            scoreText.text = "Score: " + score.ToString();
        }
        if (col.gameObject.name == "Green Key")
        {
            greenKeyGot = true;
            keyCount = keyCount + 1;
            Destroy(col.gameObject);
            keyCollect.Play();
            keyCheck();
            score = score + 1000;
            scoreText.text = "Score: " + score.ToString();
        }
        if (col.gameObject.name == "HEnterance")
        {
            SceneManager.LoadScene("Ghost");
        }
        if (col.gameObject.name == "KEnterance")
        {
            SceneManager.LoadScene("Mummy");
        }
        if (col.gameObject.name == "EEnterance")
        {
            SceneManager.LoadScene("Vampire");
        }
        if (col.gameObject.name == "GEnterance")
        {
            SceneManager.LoadScene("Werewolf");
        }
        if (col.gameObject.name == "AEnterance")
        {
            SceneManager.LoadScene("Witch");
        }
        if (col.gameObject.name == "BEnterance")
        {
            SceneManager.LoadScene("Zombie");
        }
        if (col.gameObject.name == "Exit")
        {
            SceneManager.LoadScene("Graveyard");
        }
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            score = score + 100;
            coinCollect.Play();
            scoreText.text = "Score: " + score.ToString();
        }
        if (col.gameObject.name == "WellPlate")
        {
            SceneManager.LoadScene("WellOfFears");
        }
        if (col.gameObject.tag == "Enemy"){
            TakeDamage(5);
            damage.Play();
        }
        if (col.gameObject.tag == "Heart"){
            Destroy(col.gameObject);
            health += 20;
            if (health > 100){
                health = 100;
            }
            healthBar.UpdateBar(health, 100);
            MoreHealth.Play();
        }
        if (col.gameObject.tag == "Ball"){
            Destroy(col.gameObject);
            TakeDamage(10);
            damage.Play();
        }
        if (col.gameObject.name == "GameExit"){
            SceneManager.LoadScene("Final");
        }

    }
    void keyCheck()
    {
        if (keyCount == 6)
        {
            if (SceneManager.GetActiveScene().name != "WellOfFears")
            {
                Destroy(GameObject.Find("WellOfFearsLid"));
                keyText.text = "Keys Got: 6. Head to the center!";
            }
        }
        else{
            keyText.text = "Keys Got: " + keyCount.ToString() + "/6";
        }
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
            newgame = true;
            SceneManager.LoadScene("GameOver");

        }

        if (health <= 0)
        {
            timerIsActive = false;
            newgame = true;
            SceneManager.LoadScene("GameOver");

        }

        if (SceneManager.GetActiveScene().name == "Graveyard")
        {
            if (blueKeyGot == true)
            {
                Destroy(GameObject.Find("GEnterance"));
            }
            if (purpleKeyGot == true)
            {
                Destroy(GameObject.Find("HEnterance"));
            }
            if (yellowKeyGot == true)
            {
                Destroy(GameObject.Find("KEnterance"));
            }
            if (orangeKeyGot == true)
            {
                Destroy(GameObject.Find("AEnterance"));
            }
            if (redKeyGot == true)
            {
                Destroy(GameObject.Find("EEnterance"));
            }
            if (greenKeyGot == true)
            {
                Destroy(GameObject.Find("BEnterance"));
            }

        }
        if (SceneManager.GetActiveScene().name == "WellOfFears")
        {
            if (GameObject.FindGameObjectsWithTag("Switch").Length != 0)
            {
                keyText.text = "Destroy " + (GameObject.FindGameObjectsWithTag("Switch").Length).ToString() + " switches";
            }
            else
            {
                Destroy(GameObject.Find("Barrier"));
                Destroy(GameObject.Find("GrimReaper"));
                keyText.text = "Escape!";
            }
        }
    }
    void TakeDamage(int damage){
        health -= damage;
        healthBar.UpdateBar(health, 100);

    }


    public void InitialsEntered()
    {
        GetComponent<LeaderBoard>().CheckForHighScore(finalScore, playerName.text);
        enterScore.interactable = false;
    }

    public void ResetScores()
    {
        GetComponent<LeaderBoard>().ResetScores(3);
        scoreIsReset.text = "Scores will Reset";
    }


    void EndGameWin(){
        timerIsActive = false;
        finalScore = score + (int)myTimer + health;
        myFinalScore.text = "Final Score: " + finalScore.ToString();
    }

    void ResetGame(){
        keyCount = 0;
        blueKeyGot = false;
        purpleKeyGot = false;
        yellowKeyGot = false;
        orangeKeyGot = false;
        redKeyGot = false;
        greenKeyGot = false;
        score = 0;
        myTimer = 600f;
        timerIsActive = true;
        health = 100;
    }

}