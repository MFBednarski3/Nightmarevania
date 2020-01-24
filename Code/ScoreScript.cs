using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    int finalScore = 0;
    int highScore = 0;

    // Start is called before the first frame update
   /*
    void Start()
    {
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
    public void SetScore(int score){
        finalScore = score;
        newScore(finalScore);
    }

    public void newScore(int newScore){
        if (newScore > highScore){
            highScore = newScore;
            SaveScore();
        }
    }

    public int LoadHighScore(){
        if(PlayerPrefs.HasKey("HighScore")){
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        return highScore;
    }

    private void SaveScore(){
        PlayerPrefs.SetInt("HighScore", highScore);
    }

}
