using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    Text score;


    private void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        if (SetPanel.panelIsActive == true)
            score.text = "Your Score: " + Score_txt.scoreValue;
    }
}
