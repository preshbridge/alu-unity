using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;  // Add this to use AudioMixer and Snapshots

/// <summary>
/// Manages pausing, resuming, restarting, and scene navigation.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;

    // Add these variables for the AudioMixer Snapshots
    public AudioMixerSnapshot normalSnapshot;
    public AudioMixerSnapshot pausedSnapshot;
    public float transitionTime = 0.5f;  // Adjust transition time between snapshots

    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void Pause()
    {
        isPaused = true;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        pausedSnapshot.TransitionTo(transitionTime);  // Transition to paused snapshot
    }

    /// <summary>
    /// Resumes the game.
    /// </summary>
    public void Resume()
    {
        isPaused = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        normalSnapshot.TransitionTo(transitionTime);  // Transition back to normal snapshot
    }

    /// <summary>
    /// Restarts the current level.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        normalSnapshot.TransitionTo(transitionTime);  // Ensure normal snapshot is active after restart
    }

    /// <summary>
    /// Loads the Main Menu scene.
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1f;
        normalSnapshot.TransitionTo(transitionTime);  // Ensure normal snapshot is active when switching scenes
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Loads the Options scene.
    /// </summary>
    public void Options()
    {
        Time.timeScale = 1f;
        normalSnapshot.TransitionTo(transitionTime);  // Ensure normal snapshot is active when switching scenes
        SceneManager.LoadScene("Options");
    }

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
}
