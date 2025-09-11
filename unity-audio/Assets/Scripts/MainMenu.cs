using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles main menu actions.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the specified level.
    /// </summary>
    /// <param name="level">Level number to load.</param>
    public void LevelSelect(int level)
    {
        string sceneName = "Level0" + level.ToString();
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Loads the options menu.
    /// </summary>
    public void Options()
    {

        PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        
        SceneManager.LoadScene("Options");
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void Exit()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}