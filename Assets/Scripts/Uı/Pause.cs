using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    bool ispaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!ispaused)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                ispaused = true;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1;
                ispaused = false;
            }
        }
    }
}
