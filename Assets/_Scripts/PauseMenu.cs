using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    PauseInput action;

    public static bool paused = false;

    private PlayerInput playerInput;

    private void Awake()
    {
        action = new PauseInput();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => ifPausing();
    }

    private void ifPausing()
    {
        if (paused) Resume();
        else Pause();
    }

   /* private bool isPaused;*/

    public GameObject pausePanel;
    
//     public void OnPause(InputValue value)
//     {
//         Debug.Log("Pressed");
//         if (isPaused)
//         {
//             Resume();
//         }
//         else
//         {
//             Pause();
//         }
//     }

    public void Pause()
    {
        Debug.Log("Game Paused");
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        paused = true;
        Cursor.visible = true;
        /*isPaused = true;*/
    }

    public void Resume()
    {
        Debug.Log("Game Resumed");
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        Cursor.visible = true;
       /* isPaused = false;*/
    }
}
