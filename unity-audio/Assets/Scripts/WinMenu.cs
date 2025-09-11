using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the Win Menu UI.
/// </summary>
public class WinMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the Main Menu scene.
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Loads the next level or the Main Menu if on the last level.
    /// </summary>
    public void Next()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            MainMenu();
        }
    }

    /// <summary>
    /// Handles the win event.
    /// </summary>
    public void Win()
    {
        Debug.Log("You won! Displaying Win Menu.");
    }
}
