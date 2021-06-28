using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_txt : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    public int highScore ;
    public string highScoreKey = "HighScore";

    private void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score: " + scoreValue;
    }
    public string ScoreReset()
    {
        scoreValue = 0;
        score.text = "" + scoreValue;
        return score.text;
    }
    private void OnDisable()
    {
        if (scoreValue > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, scoreValue);
            PlayerPrefs.Save();
        }
    }

}
