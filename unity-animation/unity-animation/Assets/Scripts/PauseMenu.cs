using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject _pauseCanvas;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
   
            if (isPaused)
            {
                Resume();  
            }
            else
            {
                Pause();  
            }
        }
    }

    /// <summary>
    /// pause method to pause to game
    /// </summary>
    public void Pause()
    {
        _pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    /// <summary>
    /// resume method to resume the game
    /// </summary>
    public void Resume()
    {
        _pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    /// <summary>
    /// restart the game function
    /// </summary>

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// mainmenu
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    /// <summary>
    /// options
    /// </summary>

    public void Options()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Options");
    }
}
