using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;
    bool gameIsPause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }
}
