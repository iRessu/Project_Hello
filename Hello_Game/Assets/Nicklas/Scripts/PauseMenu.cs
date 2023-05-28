using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ResumeButton()
    {
        Resume();
    }

    public void MenuButton()
    {
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }


    void Resume()
    {
        pauseMenuUI.SetActive(false);
        FindObjectOfType<PlayerMovement>().enabled = true;
        Cursor.visible = false;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        FindObjectOfType<PlayerMovement>().enabled = false;
        Cursor.visible = true;
        GameIsPaused = true;
    }
}
