using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;

    public bool pause;
    void Start()
    {
        pause = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                PauseGame();
            }
            if (pause)
            {
                ContinueGame();
            }
        }
    }
    private void PauseGame()
    {
        pause = true;
        Time.timeScale = 0;
        
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        pause = false;
        Time.timeScale = 1;
        
        //enable the scripts again
    }
}
