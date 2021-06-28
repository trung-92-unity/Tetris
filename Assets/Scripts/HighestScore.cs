using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour
{
    public Score_txt hScore;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
        hScore.highScore = PlayerPrefs.GetInt(hScore.highScoreKey, hScore.highScore);
        score.text = "Highest: " + hScore.highScore;
    }

    
}
