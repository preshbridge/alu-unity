using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text finalTimeText;

    private float startTime;
    private bool timerStarted;

    private void Start()
    {
        timerStarted = false;
    }

    private void Update()
    {
        if (timerStarted)
        {
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        timerStarted = true;
    }

    public void StopTimer()
    {
        timerStarted = false;
    }

    private void UpdateTimerText(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f);

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }

    public void Win()
    {
        float finalTime = Time.time - startTime;
        StopTimer();
        finalTimeText.text = string.Format("{0:00}:{1:00}.{2:00}",
            Mathf.FloorToInt(finalTime / 60f), Mathf.FloorToInt(finalTime % 60f), Mathf.FloorToInt((finalTime * 100f) % 100f));
    }
}
