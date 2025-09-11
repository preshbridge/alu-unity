using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer;
    private bool originalInvertedState;
    private float originalBGMVolume;
    private float originalSFXVolume;

    private void Start()
    {
        originalInvertedState = PlayerPrefs.GetInt("isInverted", 0) == 1;
        invertYToggle.isOn = originalInvertedState;

        float savedBGMVolume = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
        bgmSlider.value = savedBGMVolume;
        SetBGMVolume(savedBGMVolume);
        originalBGMVolume = savedBGMVolume;

        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        sfxSlider.value = savedSFXVolume;
        SetSFXVolume(savedSFXVolume);
        originalSFXVolume = savedSFXVolume;

        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void Apply()
    {
        bool isInverted = invertYToggle.isOn;
        PlayerPrefs.SetInt("isInverted", isInverted ? 1 : 0);

        PlayerPrefs.SetFloat("BGMVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();

        string previousScene = PlayerPrefs.GetString("previousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }

    public void Back()
    {
        invertYToggle.isOn = originalInvertedState;
        bgmSlider.value = originalBGMVolume;
        sfxSlider.value = originalSFXVolume;

        SetBGMVolume(originalBGMVolume);
        SetSFXVolume(originalSFXVolume);

        string previousScene = PlayerPrefs.GetString("previousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }

    public void SetBGMVolume(float sliderValue)
    {
        float dBValue = Mathf.Log10(sliderValue) * 20;
        audioMixer.SetFloat("BGMVolume", dBValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        float dBValue = Mathf.Log10(sliderValue) * 20;
        audioMixer.SetFloat("SFXVolume", dBValue);
    }
}
