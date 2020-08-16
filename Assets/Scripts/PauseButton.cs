using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public Button pauseButton;
    public Button resumeButton;
    void Start()
    {
       
        pauseButton = GameObject.FindGameObjectWithTag("Pause Button").GetComponent<Button>();
        pauseButton.onClick.AddListener(Pause);
       //esumeButton = GameObject.FindGameObjectWithTag("Resume Button").GetComponent<Button>();
      //resumeButton.onClick.AddListener(Resume);
        pauseMenuUI.SetActive(false);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Debug.Log("Game Paused");
        resumeButton = GameObject.FindGameObjectWithTag("Resume Button").GetComponent<Button>();
        resumeButton.onClick.AddListener(Resume);
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        
        Debug.Log("Game resumed");
    }
   /*rivate void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else Pause();
        }
    }*/
}