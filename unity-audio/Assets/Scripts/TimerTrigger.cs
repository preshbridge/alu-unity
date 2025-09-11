using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && timer != null)
        {
            timer.StartTimer();
            gameObject.SetActive(false); 
        }
    }
}
