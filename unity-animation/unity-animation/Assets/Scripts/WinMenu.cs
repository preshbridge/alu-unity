using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        int _activeScene = SceneManager.GetActiveScene().buildIndex;
        if (_activeScene < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(_activeScene + 1);
        }
        else
        {
            MainMenu();
        }
    }

    public void Win()
    {
        Debug.Log("You won! Displaying Win Menu.");
    }
}
