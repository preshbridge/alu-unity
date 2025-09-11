using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public Toggle _invertYToggle;
    private string previousScene;

    private void Start()
    {
        bool isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
        _invertYToggle.isOn = isInverted;

        previousScene = PlayerPrefs.GetString("PreviousScene", "MainMenu");
    }

    public void Apply()
    {
        bool isInverted = _invertYToggle.isOn;
        PlayerPrefs.SetInt("InvertY", isInverted ? 1 : 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(previousScene);
    }
  
    public void Back()
    {
        SceneManager.LoadScene(previousScene);
    }
}
