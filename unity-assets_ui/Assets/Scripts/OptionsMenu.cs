using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles options menu.
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    private bool originalInvertedState;

    /// <summary>
    /// Loads Invert Y-Axis state.
    /// </summary>
    private void Start()
    {
        originalInvertedState = PlayerPrefs.GetInt("isInverted", 0) == 1;
        invertYToggle.isOn = originalInvertedState;
    }

    /// <summary>
    /// Saves settings and returns.
    /// </summary>
    public void Apply()
    {
        bool isInverted = invertYToggle.isOn;
        PlayerPrefs.SetInt("isInverted", isInverted ? 1 : 0);
        PlayerPrefs.Save();

        string previousScene = PlayerPrefs.GetString("previousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }

    /// <summary>
    /// Discards changes and returns.
    /// </summary>
    public void Back()
    {
        invertYToggle.isOn = originalInvertedState;
        string previousScene = PlayerPrefs.GetString("previousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }
}
