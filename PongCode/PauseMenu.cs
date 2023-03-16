using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public bool GameIsPaused = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) //when escape key is pressed

        {
            if (GameIsPaused == false)
            {
                GameIsPaused = true;
                PauseMenuUI.SetActive(true);
                AudioListener.pause = true; 
            }
            
            else
            {
                GameIsPaused = false;
                PauseMenuUI.SetActive(false);
            }
            
        } 


    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true); //shows the pause menu and its child objects, the panels & buttons
        Time.timeScale = 0f;  //freezes time in the game world, effectively pausing
       GameIsPaused = true;  //we use this boolean to track if the game is paused

    }

    public void Resume(bool tf)
    {
        PauseMenuUI.SetActive(false); //hides the pause menu

        Time.timeScale = 1f;  //starts time in the game world
        GameIsPaused = tf;  //we use this boolean to track if the game is paused
    }

    public void LoadMenu(bool tf)
    {
        Time.timeScale = 1f;
        GameIsPaused = tf;
        SceneManager.LoadScene("PongMenu");
    }
}
