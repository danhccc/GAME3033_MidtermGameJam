using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private PlayerInput playerInput;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private bool isPaused;

    public GameObject pausePanel;
    
    public void onPauseButtonClicked(InputValue value)
    {
        Debug.Log("Pressed");
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        Debug.Log("Game Paused");
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        Debug.Log("Game Resumed");
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
