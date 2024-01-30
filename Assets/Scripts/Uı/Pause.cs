using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameEvent gameEvent;
    bool ispaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!ispaused)
            {
                pausePanel.SetActive(true);
                gameEvent.Raise();
                ispaused = true;
            }
            else
            {
                pausePanel.SetActive(false);
                gameEvent.Raise();
                ispaused = false;
            }
        }
    }
}
